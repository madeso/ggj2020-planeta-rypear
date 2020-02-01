using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GrabAndThrow : MonoBehaviour
{
    // carrying information
    public GameObject ThingPosition;
    private Collider2D currentItem;
    public float Impulse = 10;

    // grab information
    public GameObject HandPosition;
    public float HandRadius = 5;
    public string PickupLayerMaskName;

    private LayerMask PickupLayerMask;


    private void PickupItem()
    {
        if (this.HandPosition != null && this.HandRadius > 0)
        {
            currentItem = Physics2D.OverlapCircle(this.HandPosition.transform.position, this.HandRadius, this.PickupLayerMask);
            if (currentItem != null)
            {
                Debug.Log(string.Format("pickup thingy: {0}", currentItem.name));
            }
            else
            {
                Debug.Log("nothing");
            }

            if(currentItem != null)
            {
                currentItem.enabled = false;
                var p = currentItem.gameObject.GetComponent<Rigidbody2D>();
                p.simulated = false;
            }
        }
    }

    private void ThrowItem()
    {
        currentItem.enabled = true;
        var go = currentItem.gameObject;
        var p = go.GetComponent<Rigidbody2D>();
        p.simulated = true;
        p.AddForce(new Vector2(0, this.Impulse), ForceMode2D.Impulse);
        this.currentItem = null;
    }


    void Start()
    {
        this.PickupLayerMask = LayerMask.GetMask(this.PickupLayerMaskName);
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(this.currentItem == null)
            {
                PickupItem();
            }
            else
            {
                ThrowItem();
            }
        }
        // todo: throw item if carrying
    }

    private void OnDrawGizmos()
    {
        if(this.HandPosition != null && this.HandRadius > 0)
        {
            Gizmos.DrawWireSphere(this.HandPosition.transform.position, this.HandRadius);
        }
    }

    void FixedUpdate()
    {
        // todo: move item if carrying
        if(this.currentItem != null)
        {
            var go = this.currentItem.gameObject;
            go.transform.position = this.ThingPosition.transform.position;
        }
    }
}

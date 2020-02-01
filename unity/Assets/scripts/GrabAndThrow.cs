using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GrabAndThrow : MonoBehaviour
{
    // carrying information
    public GameObject ThingPosition;

    // grab information
    public GameObject HandPosition;
    public float HandRadius = 5;
    public string PickupLayerMaskName;

    private LayerMask PickupLayerMask;


    private void PickupItem()
    {
        if (this.HandPosition != null && this.HandRadius > 0)
        {
            var collided = Physics2D.OverlapCircle(this.HandPosition.transform.position, this.HandRadius, this.PickupLayerMask);
            if (collided != null)
            {
                Debug.Log(string.Format("pickup thingy: {0}", collided.name));
            }
            else
            {
                Debug.Log("nothing");
            }
        }
    }


    void Start()
    {
        this.PickupLayerMask = LayerMask.GetMask(this.PickupLayerMaskName);
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            PickupItem();
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
    }
}

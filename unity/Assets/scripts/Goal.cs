using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(string.Format("Goal collided with {0}", collision.gameObject.name));

        GameObject.Destroy(collision.gameObject);
        GameObject.Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}

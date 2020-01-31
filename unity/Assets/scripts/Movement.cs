using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed { get; set; } = 10;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var dx = Input.GetAxis("Horizontal");
        var p = this.transform.position;
        this.transform.position = new Vector3(p.x + dx * Time.deltaTime * Speed, p.y, p.z);
    }
}

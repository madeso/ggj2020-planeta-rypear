using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float Speed { get; set; } = 10;

    public float MovementSmoothing { get; set; } = .05f;

    private Vector3 m_Velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var dx = Input.GetAxis("Horizontal");

        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(dx * Speed, rb.velocity.y);
        // And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, MovementSmoothing);

    }
}

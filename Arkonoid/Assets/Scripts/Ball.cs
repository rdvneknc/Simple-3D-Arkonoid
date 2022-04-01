using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float speed = 30f;
    Rigidbody rb;
    Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * speed;
    }

     void Update()
    {
       
    }
    
    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed;
        velocity = rb.velocity;

        

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
    }
}

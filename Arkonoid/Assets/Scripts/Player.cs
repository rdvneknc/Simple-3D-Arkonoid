using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;


     void Start()
    {
        Cursor.visible = false;
        rb.GetComponent<Rigidbody>();
    }

     void FixedUpdate()
    {
        rb.MovePosition(new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 50)).x, -17, 0));
    }
}

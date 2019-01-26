using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        print("hit");
        print(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > 1)
        {
            print("SMACK");
            rb.AddRelativeForce(Vector3.forward * 500.0f);
        }
    }
}

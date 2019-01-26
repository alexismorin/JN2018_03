using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody rb;
    public int timeToDeath = 3;
    public int smackForce = 10;
    public float smackAmplify = 500.0f;

    public float speed = 1.0f;
    public float escapeSpeed = 2.0f;
    public int goldSteal = 5;
    public bool hasGold = false;

    public Transform target;
    public Transform escapeTarget;
    public GameObject gameController;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("TargetZone").transform;
        escapeTarget = GameObject.FindWithTag("EscapeZone").transform;
        gameController = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGold)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else
        {
            float step = escapeSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, escapeTarget.position, step);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //print("hit");
        //print(collision.relativeVelocity.magnitude);

        //Hit by player
        if (collision.gameObject.tag == "PlayerCollider" && collision.relativeVelocity.magnitude > smackForce)
        {
            print("SMACK");
            
            //rb.AddRelativeForce(Vector3.forward * 500.0f);
            
            // calculate force vector
            var force = transform.position - collision.transform.position;
            // normalize force vector to get direction only and trim magnitude
            force.Normalize();
            rb.AddForce(force * smackAmplify);
            //This kills the knight
            StartCoroutine(DeathTimer());
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Reaches gold
        if (other.gameObject.tag == "TargetZone")
        {
            print("stealin yer gold!");
            //Steal gold
            hasGold = true;
            gameController.GetComponent<GameController>().LoseGold(goldSteal);
        }
        //Escapes with gold
        else if (other.gameObject.tag == "EscapeZone" && hasGold)
        {
            print("I escaped!");
            //Escape
            Destroy(gameObject);
        }
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(timeToDeath);
        Destroy(gameObject);
    }
}

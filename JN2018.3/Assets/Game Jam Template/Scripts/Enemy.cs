using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Rigidbody rb;
    public int timeToDeath = 1;
    public int smackForce = 10;
    public float smackAmplify = 500.0f;

    public float speed = 1.0f;
    public float escapeSpeed = 2.0f;
    public int lootSteal = 5;
    public bool hasLoot = false;

    public Transform target;
    public Transform escapeTarget;
    public GameObject gameController;
    //public GameObject loot;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody> ();
        target = GameObject.FindWithTag ("TargetZone").transform;
        escapeTarget = GameObject.FindWithTag ("EscapeZone").transform;
        gameController = GameObject.FindWithTag ("GameController");
    }

    // Update is called once per frame
    void Update () {
        if (!hasLoot) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards (transform.position, target.position, step);
        } else {
            float step = escapeSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards (transform.position, escapeTarget.position, step);
        }
    }

    void OnCollisionEnter (Collision collision) {
        //print("hit");
        //print(collision.relativeVelocity.magnitude);

        //Hit by player
        if (collision.gameObject.tag == "PlayerCollider" && collision.relativeVelocity.magnitude > smackForce) {
            print ("SMACK");

            DropLoot ();

            rb.AddForce (collision.contacts[0].normal * smackAmplify);

            StartCoroutine (DeathTimer ());
        }

    }

    private void OnTriggerEnter (Collider other) {
        //Reaches loot
        if (other.gameObject.tag == "TargetZone") {
            print ("stealin yer loot!");
            //Steal loot
            hasLoot = true;
            gameController.GetComponent<GameController> ().LootChange (-lootSteal);
        }
        //Escapes with loot
        else if (other.gameObject.tag == "EscapeZone" && hasLoot) {
            print ("I escaped!");
            //Escape
            Destroy (gameObject);
        } else if (other.gameObject.tag == "KillZone") {
            Destroy (gameObject);
        }
    }

    public void DropLoot () {
        //Instantiate loot at current position.
        //Instantiate(loot, gameObject.transform.position, Quaternion.identity);
        hasLoot = false;
    }

    IEnumerator DeathTimer () {
        yield return new WaitForSeconds (timeToDeath);
        Destroy (gameObject);
    }
}
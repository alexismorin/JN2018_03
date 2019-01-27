using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{

    public GameObject gameController;
    public int lootValue = 0;

    public AudioSource audioSource;
    //public AudioClip drop;
    //public AudioClip collect;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //print("hit");
        //print(collision.relativeVelocity.magnitude);

        //Hit by player
        if (collision.gameObject.tag == "PlayerCollider")
        {
            //print("Loot returned");

            ///audioSource.PlayOneShot(collect,1.0f);
            gameController.GetComponent<GameController>().LootChange(lootValue);

            Destroy(gameObject);
        }


    }
}

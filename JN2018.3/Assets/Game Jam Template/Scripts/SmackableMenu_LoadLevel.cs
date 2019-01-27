using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmackableMenu_LoadLevel : MonoBehaviour {

    public AudioSource audioS;
    public int sceneToLoad;

    void OnCollisionEnter (Collision collision) {

        if (collision.gameObject.tag == "PlayerCollider" && collision.relativeVelocity.magnitude > 0.001f) {
            print ("loading");
            audioS.Play ();
            Invoke ("Load", 1f);
        }
    }

    void Load () {
        SceneManager.LoadScene (sceneToLoad, LoadSceneMode.Single);
    }
}
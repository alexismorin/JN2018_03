using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int startingGold = 100;
    public int gold;

    // Start is called before the first frame update
    void Start()
    {
        gold = startingGold;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            //Goes Back to Main Menu
            SceneManager.LoadScene(0);
        }
    }

    public void LoseGold(int loss)
    {
        gold = gold - loss;
    }
}

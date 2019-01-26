using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int startingLoot = 100;
    public int loot;

    // Start is called before the first frame update
    void Start()
    {
        loot = startingLoot;
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

    public void LootChange(int change)
    {
        loot = loot + change;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int startingLoot = 100;
    public int loot;
    
    public int enemiesKilled;

    public Text timerText;
    public float secondsCount;
    public int minuteCount;
    public int hourCount;

    public GameObject princess;

    // Start is called before the first frame update
    void Start()
    {
        loot = startingLoot;
        enemiesKilled = 0;
        secondsCount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            //Goes Back to Main Menu
            SceneManager.LoadScene(0);
        }

        if(loot == 0)
        {
            PlayerPrefs.SetInt("enemiesKilled", enemiesKilled);
            PlayerPrefs.SetFloat("secondsCount", secondsCount);
            PlayerPrefs.SetInt("minuteCount", minuteCount);
            PlayerPrefs.SetInt("hourCount", hourCount);
            SceneManager.LoadScene(2);
        }

        UpdateTimerUI();
    }

    public void LootChange(int change)
    {
        loot = loot + change;
        princess.transform.Translate(0, change, 0);
    }

    public void UpdateTimerUI()
    {
        //print("timer up");
        //set timer UI
        secondsCount += Time.deltaTime;
        
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }
}

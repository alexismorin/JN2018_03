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

        UpdateTimerUI();
    }

    public void LootChange(int change)
    {
        loot = loot + change;
    }

    public void UpdateTimerUI()
    {
        print("timer up");
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";
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

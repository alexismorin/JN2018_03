using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public int enemiesKilled;
    public float secondsCount;
    public int minuteCount;
    public int hourCount;

    public Text killText;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        enemiesKilled = PlayerPrefs.GetInt("enemiesKilled",0);
        secondsCount = PlayerPrefs.GetFloat("secondsCount", 0.0f);
        minuteCount = PlayerPrefs.GetInt("minuteCount", 0);
        hourCount = PlayerPrefs.GetInt("hourCount", 0);

        killText.text = enemiesKilled + "\n Slimes Smushed";
        timerText.text = "Lasted\n" + hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

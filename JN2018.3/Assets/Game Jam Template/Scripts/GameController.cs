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
    public Transform princessTarget;
    public Transform cageDoor;
    public float princessSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        loot = startingLoot;
        enemiesKilled = 0;
        secondsCount = 0.0f;
        princessTarget.position = princess.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            //Goes Back to Main Menu
            SceneManager.LoadScene(0);
        }

        if(loot <= 0)
        {
            //StartCoroutine(GameOver());
            PlayerPrefs.SetInt("enemiesKilled", enemiesKilled);
            PlayerPrefs.SetFloat("secondsCount", secondsCount);
            PlayerPrefs.SetInt("minuteCount", minuteCount);
            PlayerPrefs.SetInt("hourCount", hourCount);

            SceneManager.LoadScene(2);
        }

        UpdateTimerUI();

        princessTarget.position = new Vector3(princessTarget.position.x, (loot/5.0f)+6.0f, princessTarget.position.z);

        float step = princessSpeed * Time.deltaTime; // calculate distance to move
        princess.transform.position = Vector3.MoveTowards(princess.transform.position, princessTarget.position, step);
    }

    public void LootChange(int change)
    {
        loot = loot + change;
        //princessTarget.Translate(0,change/10,0);

        //princess.transform.Translate(0, change/10, 0);
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

    public void EndingCinematic()
    {
        Transform cageDoor = princess.transform.Find("PivotPorte");
        cageDoor.Rotate(0, 0, -180.0f);

    }

    

    IEnumerator GameOver()
    {
        
        //cageDoor.Rotate(0, 0, -180.0f);

        PlayerPrefs.SetInt("enemiesKilled", enemiesKilled);
        PlayerPrefs.SetFloat("secondsCount", secondsCount);
        PlayerPrefs.SetInt("minuteCount", minuteCount);
        PlayerPrefs.SetInt("hourCount", hourCount);
        
        yield return new WaitForSeconds(0);

        SceneManager.LoadScene(2);
    }

}

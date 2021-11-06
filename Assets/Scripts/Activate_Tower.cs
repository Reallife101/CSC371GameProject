
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//You need to use the UnityEngine.UI namespace in order to manipulate the UI.
using TMPro;
using HighlightPlus;

public class Activate_Tower : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;


    public GameObject clickUI;
    public bool on = false;


    public GameObject Player;
    public HighlightEffect he;

    void Start()
    {
        he = GetComponent<HighlightPlus.HighlightEffect>();

    }

    public  void selected()
    {

        he.highlighted = true;
        clickUI.SetActive(true);

        if (Input.GetKeyDown(KeyCode.F))
        {
            timerIsRunning = true;
            if (!on)
            {
                print("I got to off)");
                on = true;

            }
            else
            {
                print("I got to off)");
                on = false;
            }
        }
    }


    public  void deselected()
    {
        he.highlighted = false;
        clickUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                timerIsRunning = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (timerIsRunning)
        {
            timeText.gameObject.SetActive(true);

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Player Completed Challenge");
                timeRemaining = 0;
                timerIsRunning = false;
            }

        }
       else
        {
            timeText.gameObject.SetActive(false);
        }
    }


    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("Time Remaining:  {0:00}:{1:00}", minutes, seconds);
    }

}

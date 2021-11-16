
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//You need to use the UnityEngine.UI namespace in order to manipulate the UI.
using TMPro;

public class Activate_Tower : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;


    public GameObject clickUI;
  
    public GameObject Player;
    public GameObject Waves;
    public GameObject exit;
    public GameObject Lamp;
    public GameObject Beacon;
    [SerializeField] float startTime;
    [SerializeField] float Wave1_1TimeStart;
    [SerializeField] float Wave1_2TimeStart;
    [SerializeField] float Wave1_3TimeStart;
    [SerializeField] float Wave1_4TimeStart;

    [SerializeField] float Wave2_1TimeStart;
    [SerializeField] float Wave2_2TimeStart;
    [SerializeField] float Wave2_3TimeStart;
    [SerializeField] float Wave2_4TimeStart;

    [SerializeField] float Wave3_1TimeStart;
    [SerializeField] float Wave3_2TimeStart;
    [SerializeField] float Wave3_3TimeStart;
    [SerializeField] float Wave3_4TimeStart;
    [SerializeField] bool TowerComplete;

    public AudioSource audioSrc;
    private bool isMusicPlaying = false;

    private bool W1_1 = true, W1_2 = true, W1_3 = true, W1_4 = true;
    private bool W2_1 = true, W2_2 = true, W2_3 = true, W2_4 = true;
    private bool W3_1 = true, W3_2 = true, W3_3 = true, W3_4 = true;

    private float TotalTime;
    void Start()
    {
        TotalTime = timeRemaining;
    }


    bool IsApproximately(float a, float b, float tolerance = 0.5f)
    {
        return Mathf.Abs(a - b) < tolerance;
    }

    // Update is called once per frame
    void Update()
    {

       if (TowerComplete)
        {
            exit.SetActive(true);
            Beacon.GetComponent<Light>().color = Color.green;
            Lamp.GetComponent<Light>().color = Color.green;
            timeRemaining = 0;
            timerIsRunning = false;
            audioSrc.Stop();

            DisplayTime(timeRemaining);
            if (timeRemaining <= -5)
            {
                timerIsRunning = false;
            }
        }

       if (timerIsRunning)
        {
            timeText.gameObject.SetActive(true);
            
            if (!isMusicPlaying)
            {
                audioSrc.time = startTime;
                audioSrc.Play();
                
                isMusicPlaying = true;

            }

             if (timeRemaining > 0)
           // if (timeRemaining < 191) 
            {
                 timeRemaining -= Time.deltaTime;
                //timeRemaining = audioSrc.time;

                DisplayTime(timeRemaining);

                if (W1_1 && IsApproximately(Wave1_1TimeStart, audioSrc.time))
                {
                    W1_1 = false;
                    Waves.transform.GetChild(0).gameObject.SetActive(true);
                    exit.SetActive(false);
                }

                else if (W1_2 && IsApproximately(Wave1_2TimeStart, audioSrc.time))
                {
                    W1_2 = false;
                    Waves.transform.GetChild(1).gameObject.SetActive(true);

                }


                else if (W1_3 && IsApproximately(Wave1_3TimeStart, audioSrc.time))
                {
                    W1_3 = false;
                    Waves.transform.GetChild(2).gameObject.SetActive(true);
                }
                else if (W1_4 && IsApproximately(Wave1_4TimeStart + 10, audioSrc.time))
                {
                    W1_4 = false;
                    Waves.transform.GetChild(3).gameObject.SetActive(true);

                }

                else if (W2_1 && IsApproximately(Wave2_1TimeStart, audioSrc.time))
                {
                    W2_1 = false;
                    Waves.transform.GetChild(4).gameObject.SetActive(true);
                }
                else if (W2_2 && IsApproximately(Wave2_2TimeStart, audioSrc.time))
                {
                    W2_2 = false;
                    Waves.transform.GetChild(5).gameObject.SetActive(true);
                }
                else if (W2_3 && IsApproximately(Wave2_3TimeStart, audioSrc.time))
                {
                    W2_3 = false;
                    Waves.transform.GetChild(6).gameObject.SetActive(true);
                }
                else if (W2_4 && IsApproximately(Wave2_4TimeStart, audioSrc.time))
                {
                    W2_4 = false;
                    Waves.transform.GetChild(7).gameObject.SetActive(true);
                }
                
                else if (W3_1 && IsApproximately(Wave3_1TimeStart, audioSrc.time))
                {
                    W3_1 = false;
                    Waves.transform.GetChild(8).gameObject.SetActive(true);
                }
                else if (W3_2 && IsApproximately(Wave3_2TimeStart, audioSrc.time))
                {
                    W3_2 = false;
                    Waves.transform.GetChild(9).gameObject.SetActive(true);
                }
                else if (W3_3 && IsApproximately(Wave3_3TimeStart, audioSrc.time))
                {
                    W3_3 = false;
                    Waves.transform.GetChild(10).gameObject.SetActive(true);

                }
                else if (W3_4 && IsApproximately(Wave3_4TimeStart, audioSrc.time))
                {
                    W3_4 = false;
                    Waves.transform.GetChild(11).gameObject.SetActive(true);
                }
                
                 
            }

             if (timeRemaining < 0)
            {
                timeRemaining -= Time.deltaTime;
                //timeRemaining = audioSrc.time;
                exit.SetActive(true);
                Beacon.GetComponent<Light>().color = Color.green;
                Lamp.GetComponent<Light>().color = Color.green;

                DisplayTime(timeRemaining);
                if (timeRemaining <= -5)
                {
                    timerIsRunning = false;
                }
            }



        }
       else
        {
            timeText.gameObject.SetActive(false);
        }
    }

    
    
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeText.text = string.Format("Challenge Completed!");
            return;
        }
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("Survive:  {0:00}:{1:00}", minutes, seconds);
    }

}

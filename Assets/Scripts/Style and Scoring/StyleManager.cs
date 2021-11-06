using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EZCameraShake;

public class StyleManager : MonoBehaviour
{
    [SerializeField]
    float killStreakPeriod = 5f;

    [SerializeField]
    int pointsPerKill = 100;

    [SerializeField]
    int cRatingMin = 3;

    [SerializeField]
    int bRatingMin = 5;

    [SerializeField]
    int aRatingMin = 7;

    [SerializeField]
    int SRatingMin = 10;

    [SerializeField]
    int SSSRatingMin = 15;

    [SerializeField]
    AudioHandler ah;

    public int numKills;
    private int prevKills;
    private string prevRating;

    private healthBar hb;
    private GameObject ui;
    private scoreManager sm;
    private int scoreLevel;

    public TMP_Text comboText;
    public TMP_Text rating;


    void Start()
    {
        hb = transform.GetChild(0).gameObject.GetComponentInChildren<healthBar>();
        hb.sliderMax(killStreakPeriod);
        hb.setSlider(0);
        ui = transform.GetChild(0).gameObject;
        sm = transform.parent.GetComponentInChildren<scoreManager>();
        numKills = 0;
        prevKills = 0;
        prevRating = "";
        scoreLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {

        // If we get kill, start the combo bar
        if (prevKills == 0 && numKills > 0)
        {
            ui.SetActive(true);
            hb.setSlider(killStreakPeriod);
        }

        float curVal = hb.getValue();


        if (curVal > 0)
        {
            hb.setSlider(Mathf.Max(curVal - Time.deltaTime, 0));
        }

        if (curVal<=0)
        {
            ui.SetActive(false);
            sm.score += numKills * pointsPerKill;
            numKills = 0;
            prevKills = 0;
            scoreLevel = 0;
            prevRating = "";
        }

        if (numKills > prevKills)
        {
            hb.setSlider(killStreakPeriod);
            comboText.text = "Combo: " + numKills;
            rating.text = getRating(numKills);
        }

        if (prevRating != rating.text)
        {
            CameraShaker.Instance.ShakeOnce(8f, 10f, 0.1f, .5f);
            playRankup();
        }

        prevRating = rating.text;
        prevKills = numKills;
    }

    void playRankup()
    {
        switch (scoreLevel)
        {
            case 0:
                // D
                ah.playDRankup();
                break;
            case 1:
                //C
                ah.playCRankup();
                break;
            case 2:
                // B
                ah.playBRankup();
                break;
            case 3:
                //A
                ah.playARankup();
                break;
            case 4:
                //S
                ah.playSRankup();
                break;
            case 5:
                //SSS
                ah.playSSSRankup();
                break;
        }
        scoreLevel += 1;
    }

    string getRating(int kills)
    {
        if (kills >=SSSRatingMin)
        {
            return "SSS";
        } else if (kills >= SRatingMin)
        {
            return "S";
        }
        else if (kills >= aRatingMin)
        {
            return "A";
        }
        else if (kills >= bRatingMin)
        {
            return "B";
        }
        else if (kills >= cRatingMin)
        {
            return "C";
        } else
        {
            return "D";
        }
    }
}

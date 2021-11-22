using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    private TMP_Text scoreUI;
    public int score;
    public int levelThreshold;

    [SerializeField] float thresholdMultipler = 1.5f;

    [SerializeField] CharacterStats Stats;

    // Start is called before the first frame update
    void Start()
    {
        scoreUI = GetComponent<TMP_Text>();
        score = Stats.Score;
        levelThreshold = Stats.LevelThreshold;
        if (levelThreshold == 0)
        {
            Stats.LevelThreshold = levelThreshold = 500;
        }
        
    }

    // Called to add to the score
    public void AddScore(int toAdd)
    {
        score += toAdd;
        Stats.Score += toAdd;
    }

    // Called to check if Upgrade Points should be awarded
    private void checkLevelUp()
    {
        if (score >= levelThreshold)
        {
            Stats.AvailableUpgradePoints++;
            Stats.LevelThreshold = levelThreshold = (int) System.Math.Round(levelThreshold * thresholdMultipler);
        }
    }

    // Handles reseting the Character Stats Object
    private void OnApplicationQuit()
    {
        Stats.ResetToDefault();
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = "Score: " + score+"  ";
        checkLevelUp();
    }
}

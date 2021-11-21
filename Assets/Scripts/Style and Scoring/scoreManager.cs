using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    private TMP_Text scoreUI;
    public int score;

    [SerializeField] CharacterStats Stats;

    // Start is called before the first frame update
    void Start()
    {
        scoreUI = GetComponent<TMP_Text>();
        score = Stats.Score;
    }

    // Called to add to the score
    public void AddScore(int toAdd)
    {
        score += toAdd;
        Stats.Score += toAdd;
    }

    private void OnApplicationQuit()
    {
        Stats.resetToDefault();
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = "Score: " + score+"  ";
    }
}

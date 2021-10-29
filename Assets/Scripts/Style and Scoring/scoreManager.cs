using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    private TMP_Text scoreUI;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreUI = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = "Score: " + score+"  ";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandleUpgradePoints : MonoBehaviour
{
    [SerializeField] CharacterStats Stats;

    [SerializeField] TMP_Text AvailableUpgradePoints;

    // Start is called before the first frame update
    void Start()
    {
        AvailableUpgradePoints = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        AvailableUpgradePoints.text = "Available Upgrade Points: " + Stats.AvailableUpgradePoints;
    }
}

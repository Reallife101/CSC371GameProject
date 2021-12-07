using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandlePlayerButtons : MonoBehaviour
{
    [SerializeField] TMP_Text MaxHealthText;
    [SerializeField] TMP_Text BulletDamageText;

    [SerializeField] UITextHolder healthButtonDesc;
    [SerializeField] UITextHolder bulletDamageDesc;

    [SerializeField] CharacterStats Stats;

    // Sets the intial values
    private void Start()
    {
        MaxHealthText.text = "Max Health: " + Stats.HealthMax;
        healthButtonDesc.ChangeCost(Stats.healthUpgrades + 1);
        BulletDamageText.text = "Damage: " + Stats.BulletDamage;
        bulletDamageDesc.ChangeCost(Stats.bulletUpgrades + 1);
    }

    // Handles the buttons for the health and damage block of the Weapon Rack UI
    public void HandleHealthButton()
    {
        if (Stats.IncreaseHealth(5))
        {
            MaxHealthText.text = "Max Health: " + Stats.HealthMax;
            healthButtonDesc.ChangeCost(Stats.healthUpgrades + 1);
        }
    }

    public void HandleBulletDamageButton()
    {
        if (Stats.IncreaseDamage(1))
        {
            BulletDamageText.text = "Damage: " + Stats.BulletDamage;
            bulletDamageDesc.ChangeCost(Stats.bulletUpgrades + 1);
        }
    }

    public void HandleResetButton()
    {
        Stats.ResetPlayer();
        MaxHealthText.text = "Max Health: " + Stats.HealthMax;
        BulletDamageText.text = "Damage: " + Stats.BulletDamage;
        healthButtonDesc.ChangeCost(Stats.healthUpgrades + 1);
        bulletDamageDesc.ChangeCost(Stats.bulletUpgrades + 1);
    }
}

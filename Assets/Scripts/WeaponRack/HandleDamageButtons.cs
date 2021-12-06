using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDamageButtons : MonoBehaviour
{
    [SerializeField] healthBar AOERadiusBar;
    [SerializeField] healthBar DamageBar;
    [SerializeField] healthBar FormatBar;

    [SerializeField] CharacterStats Stats;

    private void Start()
    {
        if (Stats.Format) { FormatBar.increaseValue(1); }
        int aoeDelta = Mathf.FloorToInt(Stats.DamageAOERadius - 6f) / 3;
        AOERadiusBar.setSlider(aoeDelta);
        int damageDelta = Mathf.FloorToInt(Stats.AbilityDamage - 10f) / 5;
        DamageBar.setSlider(damageDelta);
    }

    // Handles the button presses for the movement block of the Weapon Rack UI
    public void HandleAOERadiusButton()
    {
        if (Stats.IncreaseDmgAOE(3f)) { AOERadiusBar.increaseValue(1); }
    }

    public void HandleDamageButton()
    {
        if (Stats.IncreaseAbilityDmg(5)) { DamageBar.increaseValue(1); }
    }

    public void HandleFormatButton()
    {
        if (Stats.ActivateFormat()) { FormatBar.increaseValue(1); }
    }

    public void HandleResetButton()
    {
        Stats.ResetDamageAbility();
        AOERadiusBar.setSlider(0);
        DamageBar.setSlider(0);
        FormatBar.setSlider(0);
    }
}

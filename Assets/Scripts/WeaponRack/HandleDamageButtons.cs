using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDamageButtons : MonoBehaviour
{
    [SerializeField] healthBar AOERadiusBar;
    [SerializeField] healthBar DamageBar;
    [SerializeField] healthBar FormatBar;

    [SerializeField] CharacterStats Stats;

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

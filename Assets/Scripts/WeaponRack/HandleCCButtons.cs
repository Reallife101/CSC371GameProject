using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCCButtons : MonoBehaviour
{
    [SerializeField] healthBar AOERadiusBar;
    [SerializeField] healthBar DurrationBar;
    [SerializeField] healthBar RootBar;

    [SerializeField] CharacterStats Stats;

    // Handles the button presses for the movement block of the Weapon Rack UI
    public void HandleAOERadiusButton()
    {
        if (Stats.IncreaseCCAOE(5f)) { AOERadiusBar.increaseValue(1); }
    }

    public void HandleDurrationButton()
    {
        if (Stats.IncreaseCCDurration(5f)) { DurrationBar.increaseValue(1); }
    }

    public void HandleRootButton()
    {
        if (Stats.ActivateRoot()) { RootBar.increaseValue(1); }
    }

    public void HandleResetButton()
    {
        Stats.ResetCCAbility();
        AOERadiusBar.setSlider(0);
        DurrationBar.setSlider(0);
        RootBar.setSlider(0);
    }
}

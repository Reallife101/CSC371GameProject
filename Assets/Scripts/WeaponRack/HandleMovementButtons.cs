using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandleMovementButtons : MonoBehaviour
{
    [SerializeField] healthBar CoolDownBar;
    [SerializeField] healthBar DurrationRangeBar;
    [SerializeField] TMP_Text DurationRangeText;
    [SerializeField] healthBar TeleportBar;

    [SerializeField] CharacterStats Stats;

    private float delta = 10.0f / 3.0f;

    private void Start()
    {
        if (Stats.Teleport)
        {
            TeleportBar.increaseValue(1);
            DurationRangeText.text = "Range";
        }
        int cooldownDelta = Mathf.FloorToInt(Mathf.Abs(Stats.MovementCooldown - 30f)) / 3;
        CoolDownBar.setSlider(cooldownDelta);
        int durrationRangeDelta = Mathf.FloorToInt(Stats.MovementDurrationRange - 10f) / 3;
        DurrationRangeBar.setSlider(durrationRangeDelta);
    }

    // Handles the button presses for the movement block of the Weapon Rack UI
    public void HandleCoolDownButton()
    {
        if (Stats.DecreaseMoveCoolDown(delta)) { CoolDownBar.increaseValue(1); }
    }

    public void HandleDurrationRangeButton()
    {
        if (Stats.IncreaseMoveDurrationRange(delta)) { DurrationRangeBar.increaseValue(1); }
    }

    public void HandleTeleportButton()
    {
        if (Stats.ActivateTeleport())
        {
            TeleportBar.increaseValue(1);
            DurationRangeText.text = "Range";
        }
    }

    public void HandleResetButton()
    {
        Stats.ResetMovementAbility();
        CoolDownBar.setSlider(0);
        DurrationRangeBar.setSlider(0);
        TeleportBar.setSlider(0);
        DurationRangeText.text = "Durration";
    }
}

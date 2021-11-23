using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStatsPlayer : MonoBehaviour
{
    [SerializeField] shootGun Gun;
    [SerializeField] health Health;
    [SerializeField] AbilityManager AbilityManager;
    [SerializeField] CharacterStats Stats;

    private void Start()
    {
        LoadStats();
    }

    public void LoadStats()
    {
        // Sets the Bullet Damage
        Gun.BulletDamage = Stats.BulletDamage;

        // Sets the Max Health and Verifies the Current Health
        int healthDiff = Stats.HealthMax - Health.healthMax;
        Health.healthMax = Stats.HealthMax;
        if (healthDiff > 0) { Health.healthTotal += healthDiff; }
        else { if (Health.healthTotal > Stats.HealthMax) { Health.healthTotal = Stats.HealthMax; }}

        // Sets the abilites
        // Movement
        AbilityManager.MoveAlt = Stats.Teleport;
        if (AbilityManager.MoveAlt)
        {
            TeleportAbility teleport = AbilityManager.GetComponent<TeleportAbility>();
            teleport.Cooldown = Stats.MovementCooldown;
            teleport.Range = Stats.MovementDurrationRange;
        }
        else 
        {
            OverClockAbility overClock = AbilityManager.GetComponent<OverClockAbility>();
            overClock.Cooldown = Stats.MovementCooldown;
            overClock.Durration = Stats.MovementDurrationRange;
        }

        // Crowd Control
        AbilityManager.CCAlt = Stats.Root;
        if (AbilityManager.CCAlt)
        {
            RootAbility root = AbilityManager.GetComponent<RootAbility>();
            root.AOERange = Stats.CCAOERadius;
            root.Duration = Stats.CCDurration;
        }
        else
        {
            UnderClockAbility underClock = AbilityManager.GetComponent<UnderClockAbility>();
            underClock.AOERange = Stats.CCAOERadius;
            underClock.Duration = Stats.CCDurration;
        }

        // Damage
        AbilityManager.DMGAlt = Stats.Format;
        if (AbilityManager.DMGAlt)
        {
            FormatAbility format = AbilityManager.GetComponent<FormatAbility>();
            format.AOERange = Stats.DamageAOERadius;
            format.Damage = Stats.AbilityDamage;
        }
        else
        {
            BurstAbility burst = AbilityManager.GetComponent<BurstAbility>();
            burst.AOERange = Stats.DamageAOERadius;
            burst.Damage = Stats.AbilityDamage;
        }
    }
}

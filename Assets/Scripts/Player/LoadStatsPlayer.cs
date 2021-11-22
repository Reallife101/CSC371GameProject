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
        Ability movement = AbilityManager.getMovementAbility();
        movement.Cooldown = Stats.MovementCooldown;
        if (AbilityManager.MoveAlt) { ((TeleportAbility)movement).Range = Stats.MovementDurrationRange; }
        else { ((OverClockAbility)movement).Durration = Stats.MovementDurrationRange; }

        // Crowd Control
        AbilityManager.CCAlt = Stats.Root;
        Ability cc = AbilityManager.getCrowdControlAbility();
        if (AbilityManager.CCAlt)
        {
            ((RootAbility)cc).AOERange = Stats.CCAOERadius;
            ((RootAbility)cc).Duration = Stats.CCDurration;
        }
        else
        {
            ((UnderClockAbility)cc).AOERange = Stats.CCAOERadius;
            ((UnderClockAbility)cc).Duration = Stats.CCDurration;
        }

        // Damage
        AbilityManager.DMGAlt = Stats.Format;
        Ability dmg = AbilityManager.getDmgAbility();
        if (AbilityManager.DMGAlt)
        {
            ((FormatAbility)dmg).AOERange = Stats.DamageAOERadius;
            ((FormatAbility)dmg).Damage = Stats.AbilityDamage;
        }
        else
        {
            ((BurstAbility)dmg).SetToRadius(Stats.DamageAOERadius);
            ((BurstAbility)dmg).Damage = Stats.AbilityDamage;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "StatsMenu")]
public class CharacterStats : ScriptableObject
{
    // Player Stats
    [SerializeField] private const int defaultHealthMax = 100; 
    public int HealthMax;

    [SerializeField] private const int defaultBulletDamage = 5;
    public int BulletDamage;


    // Score & Upgrade Points
    [SerializeField] private const int defaultUpgradePoints = 0;
    public int TotalUpgradePoints;
    public int AvailableUpgradePoints;
    public int SpentUpgradePointsPlayer;
    public int SpentUpgradePointsMovement;
    public int SpentUpgradePointsCC;
    public int SpentUpgradePointsDamage;

    public int Score;


    // Abilty Stats

    // Movement Abilty
    [SerializeField] private const float defaultMovementCooldown = 30f;
    public float MovementCooldown;

    [SerializeField] private const float defaultMovementDurration = 10f;
    public float MovementDurration;

    [SerializeField] private const float defaultMovementRange = 10f;
    public float MovementRange;

    [SerializeField] private const bool defaultTeleport = false;
    public bool Teleport;


    // CrowdControl Abilitiy
    [SerializeField] private const float defaultCCAOERadius = 10f;
    public float CCAOERadius;

    [SerializeField] private const float defaultCCDurration = 10f;
    public float CCDurration;

    [SerializeField] private const bool defaultRoot = false;
    public bool Root;


    // Damage Ability
    [SerializeField] private const float defaultDamageAOERadius = 10f;
    public float DamageAOERadius;

    [SerializeField] private const int defaultAbilityDamage = 10;
    public int AbilityDamage;

    [SerializeField] private const bool defaultFormat = false;
    public bool Format;

    
    // Sets Individual Sections back to default states, and refunds UpgradePoints
    public void ResetPlayer()
    {
        HealthMax = defaultHealthMax;
        BulletDamage = defaultBulletDamage;
        AvailableUpgradePoints += SpentUpgradePointsPlayer;
        SpentUpgradePointsPlayer = 0;
    }

    public void ResetMovementAbility()
    {
        MovementCooldown = defaultMovementCooldown;
        MovementDurration = defaultMovementDurration;
        MovementRange = defaultMovementRange;
        Teleport = defaultTeleport;
        AvailableUpgradePoints += SpentUpgradePointsMovement;
        SpentUpgradePointsMovement = 0;
    }

    public void ResetCCAbility()
    {
        CCAOERadius = defaultCCAOERadius;
        CCDurration = defaultCCDurration;
        Root = defaultRoot;
        AvailableUpgradePoints += SpentUpgradePointsCC;
        SpentUpgradePointsCC = 0;
    }

    public void ResetDamageAbility()
    {
        DamageAOERadius = defaultDamageAOERadius;
        AbilityDamage = defaultAbilityDamage;
        Format = defaultFormat;
        AvailableUpgradePoints += SpentUpgradePointsDamage;
        SpentUpgradePointsDamage = 0;
    }

    // Used to completely reset the Characters Stats
    public void resetToDefault()
    {
        ResetPlayer();
        ResetMovementAbility();
        ResetCCAbility();
        ResetDamageAbility();

        TotalUpgradePoints = defaultUpgradePoints;
        AvailableUpgradePoints = defaultUpgradePoints;
        Score = 0;
    }
}

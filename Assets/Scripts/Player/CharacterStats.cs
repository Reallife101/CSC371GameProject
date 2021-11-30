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
    public int AvailableUpgradePoints;
    public int SpentUpgradePointsHealth;
    public int healthUpgrades = 0; 
    public int SpentUpgradePointsBulletDamage;
    public int bulletUpgrades = 0;
    public int SpentUpgradePointsMovement;
    public int SpentUpgradePointsCC;
    public int SpentUpgradePointsDamage;

    public int Score;

    [SerializeField] private const int defaultLevelThreshold = 500;
    public int LevelThreshold;


    // Abilty Stats

    // Movement Abilty
    [SerializeField] private const float defaultMovementCooldown = 30f;
    [SerializeField] private const float minMovementCooldown = 19f;
    public float MovementCooldown;

    [SerializeField] private const float defaultMovementDurrationRange = 10f;
    [SerializeField] private const float maxMovementDurrationRange = 20f;
    public float MovementDurrationRange;

    [SerializeField] private const bool defaultTeleport = false;
    public bool Teleport;


    // CrowdControl Abilitiy
    [SerializeField] private const float defaultCCAOERadius = 10f;
    [SerializeField] private const float maxCCAOERadius = 21f;
    public float CCAOERadius;

    [SerializeField] private const float defaultCCDurration = 10f;
    [SerializeField] private const float maxCCDurration = 26f;
    public float CCDurration;

    [SerializeField] private const bool defaultRoot = false;
    public bool Root;


    // Damage Ability
    [SerializeField] private const float defaultDamageAOERadius = 6f;
    [SerializeField] private const float maxDamageAOERadius = 16f;
    public float DamageAOERadius;

    [SerializeField] private const int defaultAbilityDamage = 10;
    [SerializeField] private const int maxAbilityDamage = 26;
    public int AbilityDamage;

    [SerializeField] private const bool defaultFormat = false;
    public bool Format;

    
    // Sets Individual Sections back to default states, and refunds UpgradePoints
    public void ResetPlayer()
    {
        HealthMax = defaultHealthMax;
        BulletDamage = defaultBulletDamage;
        AvailableUpgradePoints += SpentUpgradePointsHealth;
        AvailableUpgradePoints += SpentUpgradePointsBulletDamage;
        SpentUpgradePointsHealth = 0;
        SpentUpgradePointsBulletDamage = 0;
        healthUpgrades = 0;
        bulletUpgrades = 0;
    }

    public void ResetMovementAbility()
    {
        MovementCooldown = defaultMovementCooldown;
        MovementDurrationRange = defaultMovementDurrationRange;
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
    public void ResetToDefault()
    {
        ResetPlayer();
        ResetMovementAbility();
        ResetCCAbility();
        ResetDamageAbility();

        AvailableUpgradePoints = defaultUpgradePoints;
        Score = 0;
        LevelThreshold = defaultLevelThreshold;
    }

    // Used by the Weapon Rack UI to increase stats
    public bool IncreaseHealth(int toAdd)
    {
        if (AvailableUpgradePoints > healthUpgrades)
        {
            HealthMax += toAdd;
            healthUpgrades++;
            SpentUpgradePointsHealth += healthUpgrades;
            AvailableUpgradePoints -= healthUpgrades;
            return true;
        }
        return false;
    }
    
    public bool IncreaseDamage(int toAdd)
    {
        if (AvailableUpgradePoints > bulletUpgrades)
        {
            BulletDamage += toAdd;
            bulletUpgrades++;
            SpentUpgradePointsBulletDamage += bulletUpgrades;
            AvailableUpgradePoints -= bulletUpgrades;
            return true;
        }
        return false;
    }

    public bool DecreaseMoveCoolDown(float toSubtract)
    {
        if (AvailableUpgradePoints > 0 & (MovementCooldown - toSubtract > minMovementCooldown))
        {
            MovementCooldown -= toSubtract;
            SpentUpgradePointsMovement++;
            AvailableUpgradePoints--;
            return true;
        }
        return false;
    }

    public bool IncreaseMoveDurrationRange(float toAdd)
    {
        if (AvailableUpgradePoints > 0 & (MovementDurrationRange + toAdd < maxMovementDurrationRange))
        {
            MovementDurrationRange += toAdd;
            SpentUpgradePointsMovement++;
            AvailableUpgradePoints--;
            return true;
        }
        return false;
    }

    public bool ActivateTeleport()
    {
        if (AvailableUpgradePoints >= 3 & !Teleport)
        {
            Teleport = true;
            SpentUpgradePointsMovement += 3;
            AvailableUpgradePoints -= 3;
            return true;
        }
        return false;
    }

    public bool IncreaseCCAOE(float toAdd)
    {
        if (AvailableUpgradePoints > 0 & (CCAOERadius + toAdd < maxCCAOERadius))
        {
            CCAOERadius += toAdd;
            SpentUpgradePointsCC++;
            AvailableUpgradePoints--;
            return true;
        }
        return false;
    }

    public bool IncreaseCCDurration(float toAdd)
    {
        if (AvailableUpgradePoints > 0 & (CCDurration + toAdd < maxCCDurration))
        {
            CCDurration += toAdd;
            SpentUpgradePointsCC++;
            AvailableUpgradePoints--;
            return true;
        }
        return false;
    }

    public bool ActivateRoot()
    {
        if (AvailableUpgradePoints >= 3 & !Root)
        {
            Root = true;
            SpentUpgradePointsCC += 3;
            AvailableUpgradePoints -= 3;
            return true;
        }
        return false;
    }

    public bool IncreaseDmgAOE(float toAdd)
    {
        if (AvailableUpgradePoints > 0 & (DamageAOERadius + toAdd < maxDamageAOERadius))
        {
            DamageAOERadius += toAdd;
            SpentUpgradePointsDamage++;
            AvailableUpgradePoints--;
            return true;
        }
        return false;
    }

    public bool IncreaseAbilityDmg(int toAdd)
    {
        if (AvailableUpgradePoints > 0 & (AbilityDamage + toAdd < maxAbilityDamage))
        {
            AbilityDamage += toAdd;
            SpentUpgradePointsDamage++;
            AvailableUpgradePoints--;
            return true;
        }
        return false;
    }

    public bool ActivateFormat()
    {
        if (AvailableUpgradePoints >= 3 & !Format)
        {
            Format = true;
            SpentUpgradePointsDamage += 3;
            AvailableUpgradePoints -= 3;
            return true;
        }
        return false;
    }
}

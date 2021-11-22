using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstAbility : Ability
{
    [SerializeField] GameObject BurstEffect;

    public int Damage = 10;
    public float AOERange = 6f;

    [SerializeField] CooldownBar cooldownbar;
    private float currentCool;

    // Used to set the intial cooldown
    private void Awake()
    {
        if (Cooldown.Equals(Mathf.NegativeInfinity))
            Cooldown = 15f;
    }

    void Update()
    {
        if (OnCooldown)
        {
            currentCool += 1.0f / Cooldown * Time.deltaTime;
            cooldownbar.SetCooldown(currentCool);
        }
    }

    public override void TriggerEffect(Camera cam, GameObject player)
    {
        // Checks if on cooldown
        if (!OnCooldown)
        {
            currentCool = 0;
            cooldownbar.SetCooldown(0);
            // Instantiates the player centered aoe damage effect
            GameObject effect = Instantiate(BurstEffect, player.transform.position,
                new Quaternion(0f, 0f, 0f, 0f));
            effect.transform.localScale = new Vector3(2f * AOERange, 1f, 2f * AOERange);
            effect.GetComponent<DamageEffect>().damage = Damage;
            StartCoroutine(HandleCoolDown());
        }
    }

    public override int isUpgrade()
    {
        return 0;
    }

    public void SetToRadius(float newValue)
    {
        AOERange = newValue;
    }
}

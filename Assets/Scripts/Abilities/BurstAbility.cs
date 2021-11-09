using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstAbility : Ability
{
    [SerializeField] GameObject BurstEffect;

    public int Damage = 10;
    public float AOERange = 6f;

    // Used to set the intial cooldown
    private void Awake()
    {
        if (Cooldown.Equals(Mathf.NegativeInfinity))
            Cooldown = 15f;
    }

    public override void TriggerEffect(Camera cam, GameObject player)
    {
        // Checks if on cooldown
        if (!OnCooldown)
        {
            // Instantiates the player centered aoe damage effect
            GameObject effect = Instantiate(BurstEffect, player.transform.position,
                new Quaternion(0f, 0f, 0f, 0f));
            effect.transform.localScale = new Vector3(2f * AOERange, 1f, 2f * AOERange);
            effect.GetComponent<DamageEffect>().damage = Damage;
            StartCoroutine(HandleCoolDown());
        }
    }
}

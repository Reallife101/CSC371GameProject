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

    private AudioSource au;
    [SerializeField] AudioClip abilityNoise;

    // Used to set the intial cooldown
    private void Awake()
    {
        if (Cooldown.Equals(Mathf.NegativeInfinity))
            Cooldown = 15f;
        au = GetComponent<AudioSource>();
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
            au.PlayOneShot(abilityNoise);
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

}

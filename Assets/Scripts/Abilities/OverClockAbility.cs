using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverClockAbility : Ability
{
    [SerializeField] float percentageIncrease = .5f;
    public float Durration = 2f;
    [SerializeField] CooldownBar cooldownbar;
    private float currentCool;

    [SerializeField] Camera cam;

    private AudioSource au;
    [SerializeField] AudioClip abilityNoise;

    // Sets Intial CoolDown
    private void Awake()
    {
        if (Cooldown.Equals(Mathf.NegativeInfinity))
            Cooldown = 30f;
        au = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (OnCooldown)
        {
            currentCool += 1.0f / (Cooldown + Durration) * Time.deltaTime;
            cooldownbar.SetCooldown(currentCool);
        }
    }

    public override void TriggerEffect(Camera cam, GameObject player)
    {
        if(!OnCooldown)
        {
            au.PlayOneShot(abilityNoise);
            currentCool = 0;
            cooldownbar.SetCooldown(0);
            StartCoroutine(HandleOverClock(player));
        }
    }

    // Does the actual work of speeding the player up and then triggering the cool down after the effect ends
    private IEnumerator HandleOverClock(GameObject player)
    {
        movement m = player.GetComponent<movement>();
        float normalSpeed = m.movementSpeed;
        m.movementSpeed = m.movementSpeed * (1f + percentageIncrease);
        OnCooldown = true;
        cam.backgroundColor = Color.green;
        yield return new WaitForSecondsRealtime(Durration);
        m.movementSpeed = normalSpeed;
        StartCoroutine(HandleCoolDown());
    }
}

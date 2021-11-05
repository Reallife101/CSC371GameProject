using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverClockAbility : Ability
{
    [SerializeField] float percentageIncrease = .5f;
    public float durration = 10f;

    // Sets Intial CoolDown
    private void Awake()
    {
        Cooldown = 30f;
        OnCooldown = false;
    }

    public override void TriggerEffect(Camera cam, GameObject player)
    {
        if(!OnCooldown)
        {
            StartCoroutine(HandleOverClock(player));
        }
    }

    private IEnumerator HandleOverClock(GameObject player)
    {
        movement m = player.GetComponent<movement>();
        float normalSpeed = m.movementSpeed;
        m.movementSpeed = m.movementSpeed * (1f + percentageIncrease);
        OnCooldown = true;
        yield return new WaitForSecondsRealtime(durration);
        m.movementSpeed = normalSpeed;
        StartCoroutine(HandleCoolDown());
    }
}

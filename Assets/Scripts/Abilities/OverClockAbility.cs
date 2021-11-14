using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverClockAbility : Ability
{
    [SerializeField] float percentageIncrease = .5f;
    public float Durration = 2f;

    // Sets Intial CoolDown
    private void Awake()
    {
        if (Cooldown.Equals(Mathf.NegativeInfinity))
            Cooldown = 30f;
    }

    public override void TriggerEffect(Camera cam, GameObject player)
    {
        if(!OnCooldown)
        {
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
        yield return new WaitForSecondsRealtime(Durration);
        m.movementSpeed = normalSpeed;
        StartCoroutine(HandleCoolDown());
    }

    public override int isUpgrade()
    {
        return 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionAbility : Ability
{
    // Sets Cooldown
    private void Awake()
    {
        Cooldown = 60f;
        OnCooldown = false;
    }

    public override void TriggerEffect(Camera cam, GameObject player)
    {
        if(!OnCooldown)
        {
            // Gets health object and sets the restore amount
            health h = player.GetComponent<health>();
            int restore = h.healthMax / 2;

            // If the amount restored would bea bove max health instead set to max
            if (h.healthTotal + restore > h.healthMax)
            {
                h.addHealth(h.healthMax - h.healthTotal);
            }
            else
            {
                h.addHealth(restore);
            }

            StartCoroutine(HandleCoolDown());
        }
    }
}

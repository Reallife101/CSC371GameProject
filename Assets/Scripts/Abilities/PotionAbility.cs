using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionAbility : Ability
{

    [SerializeField] CooldownBar cooldownbar;
    private float currentCool;
    // Sets Cooldown
    private void Awake()
    {
        if (Cooldown.Equals(Mathf.NegativeInfinity))
            Cooldown = 60f;
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
        if (!OnCooldown)
        {
            // Sets the health object and restore amount
            health h = player.GetComponent<health>();
            int restore = h.healthMax / 2;

            // Does not trigger if at max health
            if (!h.healthMax.Equals(h.healthTotal))
            {
                currentCool = 0;
                cooldownbar.SetCooldown(0);
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

    public override int isUpgrade()
    {
        return 0;
    }
}

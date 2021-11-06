using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAbility : Ability
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallMask;

    public GameObject effectTrigger;

    // Used to set the intial cooldown
    private void Awake()
    {
        Cooldown = 15f;
        OnCooldown = false;
    }

    public override void TriggerEffect(Camera cam, GameObject player)
    {
        // Checks if on cooldown
        if (!OnCooldown)
        {
            // Instantiates the aoe effet
            GameObject rootEffect = Instantiate(effectTrigger,
                transform.position,
                new Quaternion(0f, 0f, 0f, 0f),
                player.transform);
            StartCoroutine(HandleCoolDown());

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAbility : Ability
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallMask;
    [SerializeField] float SpeedMultiplier = 0f;
    [SerializeField] GameObject RootEffect;
    [SerializeField] float Range = 50f;

    public float AOERange = 10f;
    public float Duration = 10f;

    // Used to set the intial cooldown
    private void Awake()
    {
        if (Cooldown.Equals(Mathf.NegativeInfinity))
            Cooldown = 25f;
    }

    public override void TriggerEffect(Camera cam, GameObject player)
    {
        // Gets the target position
        Vector3 targetHitPoint = getTargetPoint(cam, groundMask, wallMask, player.transform.position);
        if (!targetHitPoint.Equals(Vector3.positiveInfinity) & !OnCooldown)
        {
            // Checks if the target point is in range
            if (InRange(targetHitPoint, player.transform.position, Range))
            {
                // Instantiates the root aoe effet
                GameObject effect = Instantiate(RootEffect, targetHitPoint, new Quaternion(0f, 0f, 0f, 0f));
                effect.transform.localScale = new Vector3(2f * AOERange, 1f, 2f * AOERange);
                effect.GetComponent<CrowdControlEffect>().speedMultiplier = SpeedMultiplier;
                effect.GetComponent<CrowdControlEffect>().duration = Duration;
                StartCoroutine(HandleCoolDown());
            }
        }
    }

    public override int isUpgrade()
    {
        return 1;
    }
}

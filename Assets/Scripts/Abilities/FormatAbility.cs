using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormatAbility : Ability
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallMask;
    [SerializeField] float Range = 30f;
    [SerializeField] GameObject FormatEffect;

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
        // Gets the target position
        Vector3 targetHitPoint = getTargetPoint(cam, groundMask, wallMask, player.transform.position);
        if (!targetHitPoint.Equals(Vector3.positiveInfinity) & !OnCooldown)
        {
            // Checks if the target point is in range
            if (InRange(targetHitPoint, player.transform.position, Range))
            {
                // Instantiates the aoe damage effect
                GameObject effect = Instantiate(FormatEffect,
                    new Vector3(targetHitPoint.x, targetHitPoint.y + 1f, targetHitPoint.z),
                    new Quaternion(0f, 0f, 0f, 0f));
                effect.transform.localScale = new Vector3(2f * AOERange, .5f, 2f * AOERange);
                effect.GetComponent<DamageEffect>().damage = Damage;
                StartCoroutine(HandleCoolDown());
            }
        }
    }
}

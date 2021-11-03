using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirewallAbility : Ability
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallMask;

    public float Range = 30f;
    public GameObject effectTrigger;

    // Used to set the intial cooldown
    private void Awake()
    {
        Cooldown = 15f;
        OnCooldown = false;
    }

    public override void TriggerEffect(Camera cam)
    {
        // Gets the Mouse posistion
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundMask) & !OnCooldown)
        {
            // Checks if there is a wall in the ray
            Vector3 targetHitPoint = hit.point;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, wallMask))
            {
                targetHitPoint.x = hit.point.x;
                targetHitPoint.z = hit.point.z;
            }

            if (InRange(targetHitPoint, transform.position))
            {
                // Instantiates the aoe effet
                Instantiate(effectTrigger,
                    new Vector3(targetHitPoint.x, targetHitPoint.y + 1f, targetHitPoint.z),
                    transform.rotation);
                StartCoroutine(HandleCoolDown());
            }
        }
    }
    private bool InRange(Vector3 a, Vector3 b)
    {
        float distance;
        distance = Vector3.Distance(new Vector3(a.x, 0f, a.z),
                                    new Vector3(b.x, 0f, b.z));
        return distance <= Range;
    }
}
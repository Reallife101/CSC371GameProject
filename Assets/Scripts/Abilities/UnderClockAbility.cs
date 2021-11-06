using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderClockAbility : Ability
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallMask;

    public float Range = 50f;
    public GameObject effectTrigger;

    // Used to set the intial cooldown
    private void Awake()
    {
        Cooldown = 20f;
        OnCooldown = false;
    }

    public override void TriggerEffect(Camera cam, GameObject player)
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

            if (InRange(targetHitPoint, player.transform.position, Range))
            {
                // Instantiates the aoe effet
                Instantiate(effectTrigger,
                    new Vector3(targetHitPoint.x, targetHitPoint.y + 1f, targetHitPoint.z),
                    new Quaternion(0f, 0f, 0f, 0f));
                StartCoroutine(HandleCoolDown());
            }
        }
    }
}

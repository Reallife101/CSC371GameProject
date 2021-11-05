using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : Ability
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallMask;
    [SerializeField] CharacterController troubleMaker;

    public float range = 15f;

    private void Awake()
    {
        Cooldown = 10f;
        OnCooldown = false;
    }

    public override void TriggerEffect(Camera cam, GameObject player)
    {
        // Gets the Mouse posistion, must be hovering over an object tagged ground
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit,
            Mathf.Infinity, groundMask) & !OnCooldown)
        {
            // Variables
            Vector3 hitPoint = hit.point;
            Vector3 playerPos = player.transform.position;
            Vector3 direction = new Vector3(hitPoint.x - playerPos.x,
                0f, hitPoint.z - playerPos.z).normalized;

            // Checks if there is a wall in the ray
            if (Physics.Raycast(playerPos, direction,
                out hit, range, wallMask))
            {
                hitPoint = new Vector3(hit.point.x - (direction.x * 0.5f),
                    playerPos.y,hit.point.z - (direction.z * 0.5f));
            }

            // Checks if the point is in range
            if (InRange(playerPos, hitPoint))
            {
                // Is in range, sets y to make sure no clipping
                hitPoint = new Vector3(hitPoint.x, playerPos.y, hitPoint.z);
            }
            else
            {
                // Is not in range, sets the vector to a new vector pased on scaled direction
                Vector3 scaledDirection = direction * range;
                hitPoint = new Vector3(playerPos.x + scaledDirection.x,
                    playerPos.y, playerPos.z + scaledDirection.z);
            }

            troubleMaker.enabled = false;
            player.transform.position = hitPoint;
            troubleMaker.enabled = true;
            StartCoroutine(HandleCoolDown());
        }
    }

    private bool InRange(Vector3 a, Vector3 b)
    {
        float distance;
        distance = Vector3.Distance(new Vector3(a.x, 0f, a.z),
                                    new Vector3(b.x, 0f, b.z));
        return distance <= range;
    }
}

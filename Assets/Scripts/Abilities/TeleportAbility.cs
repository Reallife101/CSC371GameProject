using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : Ability
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallMask;
    [SerializeField] CharacterController troubleMaker;

    public float Range = 10f;

    private void Awake()
    {
        if (Cooldown.Equals(Mathf.NegativeInfinity))
            Cooldown = 30f;
    }

    public override void TriggerEffect(Camera cam, GameObject player)
    {
        // Sets the player postion
        Vector3 playerPos = player.transform.position;
        // Gets the target point
        Vector3 hitPoint = getTargetPoint(cam, groundMask, wallMask, playerPos);

        if (!hitPoint.Equals(Vector3.positiveInfinity))
        {
            // Checks if the point is in range
            if (InRange(playerPos, hitPoint, Range))
            {
                // Is in range, sets y to make sure no clipping
                hitPoint = new Vector3(hitPoint.x, playerPos.y, hitPoint.z);
            }
            else
            {
                // Is not in range, sets the hitPoint to a new vector based on scaled direction
                Vector3 scaledDirection = new Vector3(hitPoint.x - playerPos.x, 0f,
                    hitPoint.z - playerPos.z).normalized * Range;

                hitPoint = new Vector3(playerPos.x + scaledDirection.x,
                    playerPos.y, playerPos.z + scaledDirection.z);
            }

            // Makes sure teleport will mot teleport off the ground
            if(player.GetComponent<movement>().checkMove(hitPoint))
            {
                troubleMaker.enabled = false;
                player.transform.position = hitPoint;
                troubleMaker.enabled = true;
                StartCoroutine(HandleCoolDown());
            }
        }
    }

    public override int isUpgrade()
    {
        return 1;
    }
}

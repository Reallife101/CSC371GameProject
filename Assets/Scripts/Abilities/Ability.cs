using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public bool OnCooldown = false;

    // Intlized to Negative Infinity to see if the Cooldown has been edited
    public float Cooldown = Mathf.NegativeInfinity;

    // Used to trigger effects, all Abilities will use this
    public abstract void TriggerEffect(Camera cam, GameObject player);

    // Used to handle cooldowns, Abilities must set the cooldown in thier awake function
    internal IEnumerator HandleCoolDown()
    {
        OnCooldown = true;
        yield return new WaitForSecondsRealtime(Cooldown);
        OnCooldown = false;
    }

    // For Abilities that need to check range to a target point
    internal bool InRange(Vector3 a, Vector3 b, float range)
    {
        float distance;
        distance = Vector3.Distance(new Vector3(a.x, 0f, a.z),
                                    new Vector3(b.x, 0f, b.z));
        return distance <= range;
    }

    // Gets mouse postion on ground, returns positive infinty if there is no hit
    internal Vector3 getMousePos(Camera cam, LayerMask groundMask)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundMask) & !OnCooldown)
            return hit.point;
        else
            return Vector3.positiveInfinity;
    }

    // Checks for hitting walls, returns positive infinity if there is no wall, or the point of hit with a wall boundd to the mouse hit
    internal Vector3 checkWall(LayerMask wallMask, Vector3 playerPos, Vector3 mouseHit)
    {
        // Direction vector from player pos to mouse position 
        Vector3 direction = new Vector3(mouseHit.x - playerPos.x, 0f, mouseHit.z - playerPos.z).normalized;

        // Checks if there is a wall in the ray
        if (Physics.Raycast(playerPos, direction, out RaycastHit hit, Vector3.Distance(playerPos, mouseHit), wallMask))
        {
           return new Vector3(hit.point.x - (direction.x * 0.5f), playerPos.y, hit.point.z - (direction.z * 0.5f));
        } else
        {
            return Vector3.positiveInfinity;
        }
    }

    // Combo function of getMousePos and checkWall as most uses don't need them seaperated, returns positive infinty if the mouse isn;t above the ground.
    internal Vector3 getTargetPoint(Camera cam, LayerMask groundMask, LayerMask wallMask, Vector3 playerPos)
    {
        Vector3 mousePoint = getMousePos(cam, groundMask);
        if (mousePoint.Equals(Vector3.positiveInfinity))
            return mousePoint;
        else
        {
            Vector3 wallPoint = checkWall(wallMask, playerPos, mousePoint);
            if (wallPoint.Equals(Vector3.positiveInfinity))
                return mousePoint;
            else
                return wallPoint;
        }
    }
}
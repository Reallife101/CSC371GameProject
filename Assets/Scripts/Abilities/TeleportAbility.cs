using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : Ability
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallMask;
    [SerializeField] CharacterController troubleMaker;

    public float range = 7.5f;

    public override void triggerEffect(Camera cam)
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, groundMask))
        {
            Vector3 oldHitPoint = hit.point;
            Debug.Log("hit1");
            if(!Physics.Raycast(ray, out hit, Mathf.Infinity, wallMask))
            {
                if (inRange(transform.position, oldHitPoint))
                {
                    hit.point = new Vector3(oldHitPoint.x, oldHitPoint.y + 0.1f, oldHitPoint.z);
                    troubleMaker.enabled = false;
                    transform.position = hit.point;
                    troubleMaker.enabled = true;
                }
            }
        }
    }

    private bool inRange(Vector3 a, Vector3 b)
    {
        float distance;
        distance = Vector3.Distance(new Vector3(a.x, 0f, a.z),
                                    new Vector3(b.x, 0f, b.z));
        return distance <= range;
    }
}

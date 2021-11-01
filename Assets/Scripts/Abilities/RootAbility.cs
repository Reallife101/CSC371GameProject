using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAbility : Ability
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallMask;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] CharacterController troubleMaker;

    public float range = 7.5f;

    private void Awake()
    {
        Cooldown = 10f;
        OnCooldown = false;
    }

    public override void TriggerEffect(Camera cam)
    {
        // Gets the Mouse posistion
        /*Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundMask) & !OnCooldown)
        {
            // Checks if there is a wall in the ray
            Vector3 oldHitPoint = hit.point;
            if (!Physics.Raycast(ray, out hit, Mathf.Infinity, wallMask))
            {
                // Checks if the point is in range
                if (InRange(transform.position, oldHitPoint))
                {
                    hit.point = new Vector3(oldHitPoint.x, oldHitPoint.y + 0.1f, oldHitPoint.z);
                    troubleMaker.enabled = false;
                    transform.position = hit.point;
                    troubleMaker.enabled = true;
                    StartCoroutine(HandleCoolDown());
                }
            }
        }*/
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, enemyMask);
        Debug.Log("length: " + hitColliders.Length);
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.GetComponent<moveTowardsPlayer>().enabled = false;
            Debug.Log("Frozen");
        }
        StartCoroutine(waitForFreeze(5));
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.GetComponent<moveTowardsPlayer>().enabled = true;
        }
        StartCoroutine(HandleCoolDown());
    }

    internal IEnumerator waitForFreeze(float time)
    {
        yield return new WaitForSecondsRealtime(time);
    }
}

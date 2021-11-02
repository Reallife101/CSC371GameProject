using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAbility : Ability
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallMask;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] CharacterController troubleMaker;
    private float timeFreeze = 15f;

    public float range = 7.5f;

    private void Awake()
    {
        Cooldown = 15f;
        OnCooldown = false;
    }

    public override void TriggerEffect(Camera cam)
    {
        // gets all colliders from enemy layer
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, enemyMask);
        Debug.Log("length: " + hitColliders.Length);
        //disable movement script
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.GetComponent<moveTowardsPlayer>().enabled = false;
            Debug.Log("Frozen");
        }
        StartCoroutine(waitForFreeze(timeFreeze));
        //reenable movement script
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

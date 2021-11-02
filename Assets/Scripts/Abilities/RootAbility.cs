using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAbility : Ability
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallMask;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] CharacterController troubleMaker;
    private float timeFreeze = 30f;

    public float range = 7.5f;

    private void Awake()
    {
        Cooldown = 10f;
        OnCooldown = false;
    }

    public override void TriggerEffect(Camera cam)
    {
        // Gets the Mouse posistion
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, enemyMask);
        Debug.Log("length: " + hitColliders.Length);
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.GetComponent<moveTowardsPlayer>().enabled = false;
            Debug.Log("Frozen");
        }
        StartCoroutine(waitForFreeze(timeFreeze));
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstAbility : Ability
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallMask;

    public GameObject effectTrigger;
    public Transform Player; 

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
        if (!OnCooldown)
        {            
            // Instantiates the aoe effet
            GameObject burstEffect = Instantiate(effectTrigger,
                transform.position,
                new Quaternion(0f, 0f, 0f, 0f),
                Player);
            //burstEffect.transform.localScale = new Vector3(hit.distance, 1, hit.distance);
            StartCoroutine(HandleCoolDown());
            
        }

    }
}

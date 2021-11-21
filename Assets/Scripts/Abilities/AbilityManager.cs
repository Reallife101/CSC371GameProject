using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] Ability movement;
    [SerializeField] Ability movementAlt;
    [SerializeField] Ability crowdCon;
    [SerializeField] Ability crowdConAlt;
    [SerializeField] Ability dmg;
    [SerializeField] Ability dmgAlt;
    [SerializeField] Ability potion;

    public bool MoveAlt = false;
    public bool CCAlt = false;
    public bool DMGAlt = false;

    [SerializeField] Camera cam = null;
    [SerializeField] GameObject player;
    
    [SerializeField] KeyCode moveKey = KeyCode.LeftShift;
    [SerializeField] KeyCode crowdKey = KeyCode.E;
    [SerializeField] KeyCode dmgKey = KeyCode.R;
    [SerializeField] KeyCode potionKey = KeyCode.Q;

    // Sets the cam variable to main unless overidden
    private void Start()
    {
        if (cam.Equals(null))
            cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(moveKey))
        {
            if (!MoveAlt)
            {
                movement.TriggerEffect(cam, player);
            }
            else
            {
                movementAlt.TriggerEffect(cam, player);
            }
        }

        if(Input.GetKeyDown(crowdKey))
        {
            if (!CCAlt)
            {
                crowdCon.TriggerEffect(cam, player);
            }
            else
            {
                crowdConAlt.TriggerEffect(cam, player);
            }
        }

        if(Input.GetKeyDown(dmgKey))
        {
            if (!DMGAlt)
            {
                dmg.TriggerEffect(cam, player);
            }
            else
            {
                dmgAlt.TriggerEffect(cam, player);
            }
        }

        if(Input.GetKeyDown(potionKey))
        {
            potion.TriggerEffect(cam, player);
        }
    }

    public Ability getMovementAbility()
    {
        if (MoveAlt)
        {
            return movementAlt;
        }
        else
        {
            return movement;
        }
    }

    public Ability getCrowdControlAbility()
    {
        if (CCAlt)
        {
            return crowdConAlt;
        }
        else
        {
            return crowdCon;
        }
    }

    public Ability getDmgAbility()
    {
        if (DMGAlt)
        {
            return dmg;
        }
        else
        {
            return dmgAlt;
        }
    }
}

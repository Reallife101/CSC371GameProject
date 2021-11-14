using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] Ability movement;
    [SerializeField] Ability crowdCon;
    [SerializeField] Ability dmg;
    [SerializeField] Ability potion;

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
            movement.TriggerEffect(cam, player);
        }

        if(Input.GetKeyDown(crowdKey))
        {
            crowdCon.TriggerEffect(cam, player);
        }

        if(Input.GetKeyDown(dmgKey))
        {
            dmg.TriggerEffect(cam, player);
        }

        if(Input.GetKeyDown(potionKey))
        {
            potion.TriggerEffect(cam, player);
        }
    }

    public Ability getMovementAbility()
    {
        return movement;
    }

    public Ability getCrowdControlAbility()
    {
        return crowdCon;
    }

    public Ability getDmgAbility()
    {
        return dmg;
    }

}

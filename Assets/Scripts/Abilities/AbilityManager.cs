using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] Ability movement;
    [SerializeField] Ability crowdCon;
    [SerializeField] Ability dmg;

    [SerializeField] Camera cam;
    
    [SerializeField] KeyCode moveKey = KeyCode.Alpha1;
    [SerializeField] KeyCode crowdKey = KeyCode.Alpha2;
    [SerializeField] KeyCode dmgKey = KeyCode.Alpha3;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(moveKey))
        {
            movement.TriggerEffect(cam);
        }

        if(Input.GetKeyDown(crowdKey))
        {
            crowdCon.TriggerEffect(cam);
        }

        if(Input.GetKeyDown(dmgKey))
        {
            dmg.TriggerEffect(cam);
        }
    }
}

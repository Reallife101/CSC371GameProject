using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doDamage : MonoBehaviour
{
    public int damageValue = 5;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<health>())
        {
            collider.gameObject.GetComponent<health>().takeDamage(damageValue);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveHealth : MonoBehaviour
{
    public int healthGain = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<health>())
        {
            health h = other.gameObject.GetComponent<health>();
            h.addHealth(healthGain);
            Destroy(gameObject);
        }
    }
}

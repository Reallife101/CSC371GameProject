using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootEffect : MonoBehaviour
{
    [SerializeField] float time = 0.5f;
    [SerializeField] string targetTag = "Enemy";
    [SerializeField] float timeFreeze = 15f;

    // Sets the self-destruct
    private void Awake()
    {
        StartCoroutine(HandleDestroy());
    }

    // Handle the self-destruct
    private IEnumerator HandleDestroy()
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(gameObject);
    }

    // Handles freezing enemies in the aoe
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("hitting enemy");
            // disable movement script on enemy
            other.GetComponent<moveTowardsPlayer>().enabled = false;
            StartCoroutine(waitForFreeze());
            // reenable movement script
            other.GetComponent<moveTowardsPlayer>().enabled = true;
        }
    }

    internal IEnumerator waitForFreeze()
    {
        yield return new WaitForSecondsRealtime(timeFreeze);
    }
}

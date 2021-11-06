using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstEffect : MonoBehaviour
{
    [SerializeField] float time = 0.5f;
    [SerializeField] int damage = 30;
    [SerializeField] string targetTag = "Enemy";

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

    // Handles dealing damage to enemies in the aoe
    private void OnTriggerEnter(Collider other)
    {
        // Check if enemy
        if (other.CompareTag(targetTag))
        {
            //Debug.Log("hitting enemy");
            other.GetComponent<health>().takeDamage(damage);
        }
    }
}

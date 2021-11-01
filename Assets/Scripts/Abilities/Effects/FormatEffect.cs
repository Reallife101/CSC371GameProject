using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormatEffect : MonoBehaviour
{
    [SerializeField] float time = 0.5f;
    [SerializeField] int damage = 10;
    [SerializeField] string targetTag = "Enemy";

    // Sets the self-destruct
    private void Awake()
    {
        StartCoroutine(HandleDestory());
    }

    // Handle the self-destruct
    private IEnumerator HandleDestory()
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(gameObject);
    }

    // Handles dealing damage to enemies in the aoe
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            other.GetComponent<health>().takeDamage(damage);
        }
    }
}

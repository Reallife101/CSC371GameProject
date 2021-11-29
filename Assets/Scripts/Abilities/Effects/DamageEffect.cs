using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    [SerializeField] float time = .5f;
    [SerializeField] string targetTag = "Enemy";

    public int damage = 10;

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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirewallEffect : MonoBehaviour
{
    [SerializeField] float time = 15f;
    [SerializeField] int damage = 10;
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
}
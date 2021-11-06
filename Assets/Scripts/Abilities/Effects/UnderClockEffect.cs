using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnderClockEffect : MonoBehaviour
{
    [SerializeField] float time = 0.5f;
    [SerializeField] float slowPercent = 0.5f;
    [SerializeField] float duration = 10f;
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
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSecondsRealtime(duration + 1f);
        Destroy(gameObject);
    }

    // Handles dealing damage to enemies in the aoe
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            StartCoroutine(HandleSlow(other, slowPercent, duration));
        }
    }

    private static IEnumerator HandleSlow(Collider other, float slowPercent, float duration)
    {
        float oldSpeed = other.GetComponent<NavMeshAgent>().speed;
        other.GetComponent<NavMeshAgent>().speed *= slowPercent;
        yield return new WaitForSecondsRealtime(duration);
        if (!(other == null))
        {
            other.GetComponent<NavMeshAgent>().speed = oldSpeed;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrowdControlEffect : MonoBehaviour
{
    [SerializeField] float time = 0.1f;
    [SerializeField] string targetTag = "Enemy";
    
    public float duration = 10f;
    public float speedMultiplier = 0.5f;

    // Sets the self-destruct
    private void Awake()
    {
        StartCoroutine(HandleDestory());
    }

    // Handles the self-destruct
    private IEnumerator HandleDestory()
    {
        yield return new WaitForSecondsRealtime(time);
        GetComponent<Collider>().enabled = false;
        //GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSecondsRealtime(duration + 1f);
        GetComponent<ParticleSystem>().gameObject.SetActive(false);
        Destroy(gameObject);
    }

    // Handles tagging enemies in the aoe
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            StartCoroutine(HandleSlow(other));
        }
    }

    // Handles appyling and removing the slow effect from enemies hit
    private IEnumerator HandleSlow(Collider other)
    {
        float oldSpeed = other.GetComponent<NavMeshAgent>().speed;
        other.GetComponent<NavMeshAgent>().speed *= speedMultiplier;
        yield return new WaitForSecondsRealtime(duration);
        if (!(other == null))
        {
            other.GetComponent<NavMeshAgent>().speed = oldSpeed;
        }
    }
}

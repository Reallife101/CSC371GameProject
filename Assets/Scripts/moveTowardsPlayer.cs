using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveTowardsPlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public float minDistance = 25f;
    public float maxDistance = 40f;



    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);

        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist > minDistance && dist < maxDistance)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}

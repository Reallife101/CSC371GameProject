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

    [SerializeField]
    int playerLayer = 8;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        RaycastHit hit;

        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist > minDistance && dist < maxDistance && Physics.Raycast(transform.position + Vector3.up, transform.forward, out hit, maxDistance))
        {
            if (hit.collider.gameObject.layer == playerLayer)
            {
                agent.SetDestination(player.transform.position);
            }
        }
    }
}

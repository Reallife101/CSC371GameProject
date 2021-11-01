using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveTowardsPlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    public float minDistance = 25f;
    public float maxDistance = 40f;

    private GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        RaycastHit hit;

        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist > minDistance && dist < maxDistance && Physics.Raycast(transform.position + Vector3.up, transform.forward, out hit, maxDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                agent.SetDestination(player.transform.position);
            }
        }
    }

    public IEnumerator freezePosition(float time)
    {
        Debug.Log("frozen");
        yield return new WaitForSecondsRealtime(time);   
    }
}

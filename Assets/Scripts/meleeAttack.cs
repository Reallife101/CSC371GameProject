using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    [SerializeField]
    public LayerMask playerMask;

    [SerializeField]
    int damageValue = 5;

    [SerializeField]
    float timeBetweenhits = 1.0f;

    [SerializeField]
    float meleeRange = 1.5f;

    private float timePassed;
    private GameObject player;

    private void Start()
    {
        timePassed = timeBetweenhits;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(Physics.CheckSphere(transform.position, meleeRange, playerMask))
        {
            timePassed += Time.deltaTime;

            if (timePassed >= timeBetweenhits)
            {
                player.GetComponent<health>().takeDamage(damageValue);
                timePassed = 0f;
            }
        }
    }
}

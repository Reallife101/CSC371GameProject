using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootEnemyGun : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject gun;
    public GameObject player;

    public float attackRange = 30f;

    public float shotCooldown = 0.5f;
    public float burstCooldown = 3f;
    public int numShots = 3;

    private float shotTimer = 0f;
    private float burstTimer = 0f;

    private int shotCounter = 0;



    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
        {
            transform.LookAt(player.transform);

            if (burstTimer > burstCooldown)
            {
                if (shotTimer > shotCooldown)
                {
                    Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation);
                    shotTimer = 0f;
                    shotCounter += 1;

                    if (shotCounter >= numShots)
                    {
                        shotCounter = 0;
                        burstTimer = 0f;
                    }
                }
            }
            shotTimer += Time.deltaTime;
            burstTimer += Time.deltaTime;
        }
    }
}

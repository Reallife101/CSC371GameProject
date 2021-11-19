using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBasedOnArea : MonoBehaviour
{
    public Vector3 respawnPoint;
    public GameObject player;
    private float holdTimer;
    // Start is called before the first frame update
    void Start()
    {
        holdTimer = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            holdTimer += Time.deltaTime;
            if (holdTimer > 5f)
            {
                respawn();
            }
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            holdTimer = 0;
        }




    }

    public void respawn()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = respawnPoint;
        player.GetComponent<health>().addHealth(10000);
        player.GetComponent<CharacterController>().enabled = true;

       
    }


}

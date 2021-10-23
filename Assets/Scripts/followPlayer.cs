using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 18f, player.transform.position.z - 18f);

        //transform.position = new Vector3(player.transform.position.x, 20f, player.transform.position.z);

        //transform.position = new Vector3(player.transform.position.x-1, player.transform.position.y+1.5f, player.transform.position.z - 6f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRespawn : MonoBehaviour
{
    // Start is called before the first frame update
    private bool StageStarted = false;
    void Start()
    {
        
    }
    public GameObject FinalRespawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StageStarted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StageStarted)
        {
            var RespawnLocation = GetComponentInParent<respawnHandler>();
            RespawnLocation.respawnPoint = FinalRespawnPoint.transform.position;
        }
       
    }
}

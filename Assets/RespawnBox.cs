using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBox : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 newRespawnPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var RespawnLocation = GetComponentInParent<respawnHandler>();
            RespawnLocation.respawnPoint = newRespawnPoint;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            var RespawnLocation = GetComponentInParent<respawnHandler>();
            RespawnLocation.respawnPoint = new Vector3(0,2,0);

        }
    }



}

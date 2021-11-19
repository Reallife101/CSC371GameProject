using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{

    [SerializeField] float RotationSpeed;
    private bool TowerActivated;
    // Start is called before the first frame update
    void Start()
    {
        TowerActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        TowerActivated = GetComponentInParent<Activate_Tower>().timerIsRunning;

        if (TowerActivated)
            transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
    }


    

}



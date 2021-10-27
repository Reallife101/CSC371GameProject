using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startWaves : MonoBehaviour
{
    private GameObject w;

    [SerializeField]
    GameObject walls;

    // Start is called before the first frame update
    void Start()
    {
        w = transform.GetChild(1).gameObject;
        w.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        w.SetActive(true);
        walls.SetActive(true);
    }

    public void endWaves()
    {
        walls.SetActive(false);
    }

}

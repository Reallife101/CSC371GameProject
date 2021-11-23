using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2TowerGateWay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Tower1;
    public GameObject Tower2;
    public bool Tower1Signal = false, Tower2Signal = false;
    private bool TowersAreComplete = false;
    public GameObject Entrance;
    private bool FirstTime = true;
    public GameObject Lantern1;
    public GameObject Lantern2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tower1Signal = Tower1.GetComponent<Activate_Tower>().TowerIsFinished;
        Tower2Signal = Tower2.GetComponent<Activate_Tower>().TowerIsFinished;

        if (Tower1Signal && (Lantern1.GetComponent<Light>().color != Color.green))
        {
            Lantern1.GetComponent<Light>().color = Color.green;
        }
        if (Tower2Signal && (Lantern2.GetComponent<Light>().color != Color.green))
        {
            Lantern2.GetComponent<Light>().color = Color.green;
        }
        if (Tower1Signal && Tower2Signal && FirstTime)
        {
            FirstTime = false;
            Entrance.SetActive(true);

        }

    }
}

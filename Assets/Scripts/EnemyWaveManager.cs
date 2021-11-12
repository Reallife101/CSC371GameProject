using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    [SerializeField]
    GameObject walls;
    [SerializeField]
    List<GameObject> waves;
    [SerializeField]
    GameObject end;

    private int waveNum = 1;
    private bool start = false;
    private bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        waveNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            gameObject.SetActive(false);
        } else
        if (waves[waveNum].transform.childCount == 0)
        {
            getNext().SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !start)
        {
            start = true;
            walls.SetActive(true);
            waves[waveNum].SetActive(true);
        }
    }

    public void restart()
    {
        start = false;
        walls.SetActive(false);
        waves[waveNum].SetActive(false);
    }

    private GameObject getNext()
    {
        waveNum += 1;
        if (waveNum == waves.Capacity)
        {
            walls.SetActive(false);
            done = true;
            return end;
        }

        return waves[waveNum];
    }
}

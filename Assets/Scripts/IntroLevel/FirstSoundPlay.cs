using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSoundPlay : MonoBehaviour
{
    private bool FirstTime = true;
    public GameObject BGM;
    public float seconds;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator ExampleCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.GetComponent<AudioSource>().Stop();

        BGM.GetComponent<bgmManager>().ResumeBGM();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (FirstTime)
        {
            FirstTime = false;
            BGM.GetComponent<bgmManager>().PauseBGM();
            this.GetComponent<AudioSource>().Play();
            StartCoroutine(ExampleCoroutine(seconds));
        }

    }
}

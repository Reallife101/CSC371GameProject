using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBossFight : MonoBehaviour
{
    [SerializeField] GameObject bossFight;
    [SerializeField] GameObject bossFightUI;
    [SerializeField] List<GameObject> lazers;

    [SerializeField] AudioSource voiceline;
    [SerializeField] AudioSource background;
    [SerializeField] AudioClip bossDialogue;
    [SerializeField] AudioClip Quip;
    [SerializeField] AudioClip robot;

    public bool enabled = false;
    bool start = false;


    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (!enabled && other.tag == "Player")
        {
            enabled = true;
            bossFightUI.SetActive(true);
            bossFight.SetActive(true);

            if (start)
            {
                voiceline.PlayOneShot(Quip);
            }
            else
            {
                voiceline.PlayOneShot(bossDialogue);
                StartCoroutine(wait(5f));
            }
            start = true;
        }
    }

    public void restart()
    {
        enabled = false;
        bossFightUI.SetActive(false);
        bossFight.SetActive(false);
        voiceline.Stop();
        background.Stop();

        foreach (GameObject lazer in lazers)
        {
            lazer.SetActive(false);
        }

    }

    IEnumerator wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        background.PlayOneShot(robot);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioOnEnable : MonoBehaviour
{
    [SerializeField] AudioClip ac;
    [SerializeField] float volume;

    AudioSource au;

    private void OnEnable()
    {
        au = GetComponent<AudioSource>();
        au.PlayOneShot(ac, volume);
    }
}

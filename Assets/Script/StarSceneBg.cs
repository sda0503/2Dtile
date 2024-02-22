using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSceneBg : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audio_BGM;
    void Start()
    {
        audioSource.clip = audio_BGM;
        audioSource.Play();
    }
}

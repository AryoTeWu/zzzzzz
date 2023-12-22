using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    void Start()
    {
        PlayBGM();
    }
    public void PlayBGM() {
        bgmAudioSource.Play();
    }
}

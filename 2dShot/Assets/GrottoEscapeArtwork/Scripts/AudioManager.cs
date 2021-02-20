using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    static AudioManager curr;

    [Header("环境声音")]
    public AudioClip ambientClip;
    public AudioClip musicClip;

    AudioSource ambientSource;
    AudioSource musicSource;

    private void Awake()
    {
        curr = this;

        DontDestroyOnLoad(gameObject);

        ambientSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        StartLevelAudio();
    }

    void StartLevelAudio()
    {
        curr.ambientSource.clip = curr.ambientClip;
        curr.ambientSource.loop = true;
        curr.ambientSource.Play();
        curr.musicSource.clip = curr.musicClip;
        curr.musicSource.loop = true;
        curr.musicSource.Play();
    }
}

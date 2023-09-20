using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("Audio Source References")]
    [SerializeField] private AudioSource soundAudioSource;
    [SerializeField] private AudioSource musicAudioSource;
    [Header("Sound List")]
    [SerializeField] private AudioClip[] sounds;

    public void PlaySound(int clipIndex, float volume)
    {
        if (soundAudioSource.isPlaying)
        {
            soundAudioSource.Stop();
        }
        soundAudioSource.PlayOneShot(sounds[clipIndex], volume);
    }
    public void PlayMusic(AudioClip clip)
    {
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }
}

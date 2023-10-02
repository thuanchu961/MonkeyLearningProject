using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("Audio Source References")]
    [SerializeField] private AudioSource soundAudioSource;
    [SerializeField] private AudioSource wordAudioSource;
    [Header("Sound List")]
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private AudioClip wordClip;
    [SerializeField] private bool isPerformingA, isPerformingB;
    [SerializeField] private bool startCountdown;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instant;
    }
    private void Update()
    {
        if (startCountdown)
        {
            if (!isPerformingA)
            {
                isPerformingA = true;
                Debug.Log("A");
                PlayGuiding(10);
            }
            else if (isPerformingA && !isPerformingB)
            {
                Debug.Log("B");
                PlayGuiding(5);
            }  
        }
    }
    public bool IsSoundPlaying()
    {
        return soundAudioSource.isPlaying;
    }
    public bool IsWordPlaying()
    {
        return wordAudioSource.isPlaying;
    }
    public void PlaySound(int clipIndex, float volume)
    {
        if (soundAudioSource.isPlaying)
        {
            soundAudioSource.Stop();
        }
        soundAudioSource.PlayOneShot(sounds[clipIndex], volume);
    }
    public void PlayWord()
    {
        if (wordAudioSource.isPlaying)
        {
            wordAudioSource.Stop();
        }
        wordAudioSource.PlayOneShot(wordClip, 1f);
        
    }
    public void StopSound()
    {
        soundAudioSource.Stop();
    }
    public void ReceiveAudioClip(AudioClip clip)
    {
        wordClip = clip;
    }
    public void PlayGuiding(float delayTime)
    {
        StartCoroutine(PlayGuidingAudio(delayTime));
    }
    private IEnumerator PlayGuidingAudio(float delayTime)
    {
        isPerformingB = true;
        yield return new WaitForSeconds(delayTime);
        // Play guiding audio
        soundAudioSource.PlayOneShot(sounds[(int)Constant.SOUND.Female], 1f);
        Debug.Log("Play Guiding Audio");
        // Kiểm tra khi đang phát guiding
        while (soundAudioSource.isPlaying)
        {
            // user tap vào đồ vật thì dừng guiding
            if (gameManager.onTap)
            {
                StopSound();
                StopCountdown();
                yield break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(0.25f);
        isPerformingB = false;
    }
    public void StartCountdown()
    {
        startCountdown = true;
        isPerformingA = false;
    }
    public void StopCountdown()
    {
        startCountdown = false;
    }
}
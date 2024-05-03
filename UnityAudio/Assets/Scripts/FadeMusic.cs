using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public float fadeDuration = 1.0f;
    public float targetVolume = 0.1f;
    private float initialVolume;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeMusicVolume(backgroundMusic, targetVolume));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeMusicVolume(backgroundMusic, initialVolume));
        }
    }

    IEnumerator FadeMusicVolume(AudioSource audioSource, float targetVolume)
    {
        initialVolume = audioSource.volume;
        float currentTime = 0.0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(initialVolume, targetVolume, currentTime / fadeDuration);
            yield return null;
        }

        audioSource.volume = targetVolume;
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WaterDrip : MonoBehaviour
{
    public AudioClip[] randomSounds;
    public AudioSource audioSource;

    public float minDelay = 5f;
    public float maxDelay = 10f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Iniciar la corrutina que reproduce sonidos aleatorios automáticamente
        StartCoroutine(PlayRandomSoundPeriodically());
    }

    IEnumerator PlayRandomSoundPeriodically()
    {
        while (true)
        {
            // Esperar un tiempo aleatorio entre minDelay y maxDelay
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            // Reproducir un sonido aleatorio si hay clips disponibles y el AudioSource está configurado
            if (randomSounds.Length > 0 && audioSource != null)
            {
                int randomIndex = Random.Range(0, randomSounds.Length);
                AudioClip randomClip = randomSounds[randomIndex];
                audioSource.PlayOneShot(randomClip);
            }
        }
    }
}

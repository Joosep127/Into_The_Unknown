using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip audioClip1;
    public AudioClip audioClip2;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        StartCoroutine(PlayAudioSequence());
    }

    IEnumerator PlayAudioSequence()
    {
        // Play the first audio clip
        audioSource.clip = audioClip1;
        audioSource.Play();

        // Wait until the first audio clip finishes playing
        yield return new WaitForSeconds(audioClip1.length);

        // Play the second audio clip in loop
        audioSource.clip = audioClip2;
        audioSource.loop = true;
        audioSource.Play();
    }
}

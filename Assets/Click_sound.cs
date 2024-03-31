using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_sound : MonoBehaviour
{
    public AudioClip clickSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        // Check for mouse clicks
        if (Input.GetMouseButtonDown(0))
        {
            // Play the click sound
            audioSource.PlayOneShot(clickSound);
        }
    }
}
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip click;
    public AudioClip slideEnd;
    public AudioClip slideMiddle;
    public AudioClip slideStart;
    public AudioClip explosion;
    public AudioClip fallsound;
    public AudioClip jumpsound;
    public AudioClip shootsound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(jumpsound);
    }

    // public static void PlaySound(AudioSource sound) {
    //     GameObject soundGameObject = new GameObject("Sound");
    //     AudioSource audioSource = soundGameObject.AddComponents<AudioSource>();
    //     audioSource.PlayOneShot();
    // }

    // public AudioSource Sfx;
    // public AudioClip jumpSound; // Assign this in the Inspector
    // public AudioClip shootingSound1; // Assign this in the Inspector

    // // Example: Play jump sound
    // public void PlayJumpSound()
    // {
    //     Sfx.PlayOneShot(jumpSound);
    // }

    // // Example: Play shooting sound
    // public void PlayShootingSound()
    // {
    //     Sfx.PlayOneShot(shootingSound1);
    // }
}

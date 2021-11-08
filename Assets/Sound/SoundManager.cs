using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip diamondPickup;
    public AudioClip lightningPickup;
    public AudioClip barrierCollision;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDiamondPickup()
    {
        audioSource.clip = diamondPickup;
        audioSource.Play();
    }
    public void PlayLightningPickup()
    {
        audioSource.clip = lightningPickup;
        audioSource.Play();
    }
    public void PlayBarrierCollision()
    {
        audioSource.clip = barrierCollision;
        audioSource.Play();
    }
}

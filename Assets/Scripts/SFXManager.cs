using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip playerShotSFX;
    [SerializeField] private AudioClip barrierDestroySFX;
    [SerializeField] private AudioClip playerHitSFX;
    [SerializeField] private AudioClip playerDestroySFX;
    [SerializeField] private AudioClip getPowerUPSFX;

    public void PlayPlayerShotSFX()
    {
        audioSource.PlayOneShot(playerShotSFX);
    }
    public void PlayBarrierDestroySFX()
    {
        audioSource.PlayOneShot(barrierDestroySFX);
    }
    public void PlayPlayerHitSFX()
    {
        audioSource.PlayOneShot(playerHitSFX);
    }
    public void PlayPlayerDestroySFX()
    {
        audioSource.PlayOneShot(playerDestroySFX);
    }
    public void PlayGetPowerUPSFX()
    {
        audioSource.PlayOneShot(getPowerUPSFX);
    }
}

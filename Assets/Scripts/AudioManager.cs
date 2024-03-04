using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        audioSource.volume = DateManager.instance.musicSettingValue;
    }
}

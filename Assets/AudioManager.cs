using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource SFXsource;

    [Header("Audio Clip")]
    public AudioClip meleeSFX;
    public AudioClip projectileSFX;

    public void PlayerSFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }
}

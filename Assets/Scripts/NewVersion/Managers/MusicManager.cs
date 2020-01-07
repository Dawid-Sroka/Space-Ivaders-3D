using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip mainTheme, lossTheme;
    public void PlayTheme(AudioClip theme){
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = theme;
        audio.Play();
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    private AudioSource _audioSource;

     void Start()
     {
         _audioSource = GetComponent<AudioSource>();
     }

    // Start is called before the first frame update
    public void SoundToggle()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
            
        }
        else
        {
            _audioSource.Play();
        }
    }
}

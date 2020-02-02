using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip[] sounds;
    
    public AudioSource audioPlayer;

    void Start()
    {
        if(sounds.Length == 1)
        {
            audioPlayer.clip = sounds[0];
        }
    }


    public void PlaySound(string soundName)
    {
        if(sounds.Length != 1)
        {
            foreach(var sound in sounds)
            {
                if(sound.name == soundName)
                {
                    audioPlayer.clip = sound;
                    break;
                }
            }
        }

        audioPlayer.Play();
        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSounds : MonoBehaviour
{

    public AudioClip[] sounds;

    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayRatSound(string soundName)
    {
        if(audioPlayer.clip != null && audioPlayer.clip.name == "hammer-touchdown" && audioPlayer.isPlaying)
        {
            return;
        }
        foreach(var sound in sounds)
        {
            if(sound.name == soundName)
            {
                audioPlayer.clip = sound;
                break;
            }
        }
        audioPlayer.Play();
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip mainGame;
    public AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StartMainSong()
    {
        audioSource.volume = 0.33f;
        audioSource.clip = mainGame;
        audioSource.Play();
    }
}

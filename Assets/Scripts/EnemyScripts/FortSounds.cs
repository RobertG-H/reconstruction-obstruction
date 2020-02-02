using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortSounds : MonoBehaviour
{

    public AudioClip[] sounds;
    private float soundTargetTime = 0;
    private float timer = 0;
    
    private EnemyInputController enemyInput;
    
    public AudioSource audioPlayer;
    public AudioSource stepPlayer;
    // Start is called before the first frame update
    void Start()
    {
        enemyInput = GetComponent<EnemyInputController>();
        ResetTargetTime();

    }

    void Update()
    {
        if(enemyInput.fixable.isActive)
        {
            timer += Time.deltaTime;
            if (timer >= soundTargetTime)
            {

                int clipSelect = Random.Range(0, 3);
                if(clipSelect == 0)
                {
                    PlaySound("creak1");
                }
                else if(clipSelect == 1)
                {
                    PlaySound("creak2");
                }
                else if(clipSelect == 2)
                {
                    PlaySound("roar2");
                }
                ResetTargetTime();
            }
        }

    }

    private void ResetTargetTime()
    {
        soundTargetTime = Random.Range(5.0f, 10.0f);
        timer = 0;
    }
    public void PlaySound(string soundName)
    {
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

    //Animation event listener for step sound
    public void PlayStep()
    {
        stepPlayer.Play();
    }
}

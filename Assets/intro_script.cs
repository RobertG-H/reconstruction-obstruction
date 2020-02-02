using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class intro_script : MonoBehaviour
{

    public SpriteRenderer intro;
    public AudioSource introSound;
    private IEnumerator coroutine;
    // Start is called before the first frame update

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PlaySound()
    {
        introSound.Play();
    }
}

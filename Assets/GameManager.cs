using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] nails;
    public GameObject[] pauseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void GameOver()
    {
        //lost game
    }

    void GameWon()
    {
        //won game
    }

    void CheckPaused()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                TogglePause(true);
            } else if (Time.timeScale == 0) {
                Time.timeScale = 1;
                TogglePause(false);
            }
        }
        if(Time.timeScale == 0)
        {
            CheckReset();
        }
    }

    void CheckReset()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void TogglePause(bool status)
    {
        foreach(GameObject element in pauseUI)
        {
            element.SetActive(status);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if ('press start') {
        //     SceneManager.LoadScene("Game Scene");
        // }

        // if ('count of nails hit = all hit')
        // {
        //     GameWon();
        // }
        // else if (player.hp == 0)
        // {
        //     GameOver();
        // }
        CheckPaused();
    }
}

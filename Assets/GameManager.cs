using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public NailController[] nails;

    public FinalNail finalNail;
    public GameObject[] pauseUI;

    public int totalHitNails = 0;
    public int nailsUntilFinal = 4;

    private bool gameEnded = false;
    // Start is called before the first frame update

    void OnEnable()
    {

        PlayerController.OnPlayerDeath += GameOver;
        NailController.OnNailHit += NailHit;
        FinalNail.OnFinalNailHit += GameWon;

    }

    void OnDisable()
    {
        PlayerController.OnPlayerDeath -= GameOver;
        NailController.OnNailHit -= NailHit;
        FinalNail.OnFinalNailHit -= GameWon;
    }
    void Start()
    {
        Time.timeScale = 1;
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");
        gameEnded = true;
        Time.timeScale = 0;
    }

    void NailHit()
    {
        totalHitNails += 1;
        if (totalHitNails == nailsUntilFinal)
        {
            finalNail.showFinal();
        }
    }

    void GameWon()
    {
        Debug.Log("YOU WINIININININININININI");
        gameEnded = true;
        Time.timeScale = 0;
    }

    void CheckPaused()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                TogglePause(true);
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                TogglePause(false);
            }
        }
        if (Time.timeScale == 0)
        {
            CheckReset();
        }
    }

    void CheckReset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void TogglePause(bool status)
    {
        foreach (GameObject element in pauseUI)
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
        if (!gameEnded)
            CheckPaused();
        CheckReset();
    }
}

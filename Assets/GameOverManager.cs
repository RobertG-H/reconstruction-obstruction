using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{


    void Awake()
    {
        Time.timeScale = 1;

    }
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        CheckReset();
    }

    void CheckReset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }
}

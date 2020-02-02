using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool isStart;

    // Change from OnMouseUp to when button is pressed or something
    void OnMouseUp()
    {
        if (isStart)
        {
            SceneManager.LoadScene(2); // Change number later
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

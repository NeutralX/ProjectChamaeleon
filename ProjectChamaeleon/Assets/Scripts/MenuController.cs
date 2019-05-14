using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Boolean Easy = false;
    public Boolean Hard = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        if (Easy)
        {
            PlayerPrefs.SetString("Difficulty", "easy");
        } else if (Hard)
        {
            PlayerPrefs.SetString("Difficulty", "hard");
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("LoadingScene");
    }

    public void easyMode()
    {
        Easy = true;
    }
    
    public void hardMode()
    {
        Hard = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

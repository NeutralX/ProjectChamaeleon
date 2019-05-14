using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject TinyWoodsFloor1;
    public GameObject TinyWoodsFloor2;
    public GameObject pauseScreen;
    public GameObject winScreen;
    public GameObject BossFloor;
    public GameObject Bulbasaur;
    
    public GameObject prefabRaticate;
    public GameObject prefabBoss;
    public GameObject prefabApple;

    private TimerController timer;

    private AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Bulbasaur").GetComponent<TimerController>();
        backgroundMusic = GetComponent<AudioSource>();
        TinyWoodsFloor1.SetActive(true);
        TinyWoodsFloor2.SetActive(false);
        BossFloor.SetActive(false);
        Bulbasaur.transform.position = new Vector3(-4f, -1.54606f, 1f);
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
                backgroundMusic.UnPause();
            }
            else
            {
                Time.timeScale = 0;
                backgroundMusic.Pause();
                pauseScreen.SetActive(true);
            }
            
        }

        if (BossFloor.activeSelf)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0)
            {
                gameEnded();
            }
        }
    }
    
    public void ChangeFloor()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(false);
        }
        if (TinyWoodsFloor1.activeSelf)
        {
            TinyWoodsFloor1.SetActive(false);
            Bulbasaur.transform.position = new Vector3(5.4f, -5.57f, 1);
            TinyWoodsFloor2.SetActive(true);
        } else if (TinyWoodsFloor2.activeSelf)
        {
            TinyWoodsFloor2.SetActive(false);
            Bulbasaur.transform.position = new Vector3(0.73f, -0.65f, 1f);
            BossFloor.SetActive(true);
            Instantiate(prefabBoss, new Vector3(0.63f, 3.32f, 1f), Quaternion.identity);
            Instantiate(prefabApple, new Vector3(2.62f, 0.16f, 1f), Quaternion.identity);
            
        }
    }

    public void gameEnded()
    {
        timer.SendMessage("Finish");
        winScreen.SetActive(true);
        StartCoroutine(waitWinTime());
    }

    IEnumerator waitWinTime()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");

    }


    public void RestartGame()
    {
        //ResetTimeScale();
        SceneManager.LoadScene("GameScene");
    }
    
    
}

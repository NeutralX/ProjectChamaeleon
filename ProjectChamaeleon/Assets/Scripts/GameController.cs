using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject TinyWoodsFloor1;
    public GameObject TinyWoodsFloor2;
    public GameObject BossFloor;
    public GameObject Bulbasaur;
    public GameObject Raticate;

    private int actualFloor;
    // Start is called before the first frame update
    void Start()
    {
        TinyWoodsFloor1.SetActive(true);
        TinyWoodsFloor2.SetActive(false);
        BossFloor.SetActive(false);
        int actualFloor = 1;
        Bulbasaur.transform.position = new Vector3(-4f, -1.54606f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangeFloor()
    {
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
        }
    }


    public void RestartGame()
    {
        //ResetTimeScale();
        SceneManager.LoadScene("GameScene");
    }
}

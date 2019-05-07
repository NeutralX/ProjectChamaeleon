using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject TinyWoodsFloor1;
    public GameObject TinyWoodsFloor2;
    public GameObject Bulbasaur;
    public GameObject Raticate;

    private int actualFloor;
    // Start is called before the first frame update
    void Start()
    {
        TinyWoodsFloor1.SetActive(true);
        TinyWoodsFloor2.SetActive(false);
        int actualFloor = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangeFloor()
    {
        TinyWoodsFloor1.SetActive(false);
        Bulbasaur.transform.position = new Vector3(5.4f,-5.57f,1);
        TinyWoodsFloor2.SetActive(true);
       
    }


    public void RestartGame()
    {
        //ResetTimeScale();
        SceneManager.LoadScene("SampleScene");
    }
}

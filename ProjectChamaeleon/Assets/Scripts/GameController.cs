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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangeFloor()
    {

    }
    
    
    public void RestartGame()
    {
        //ResetTimeScale();
        SceneManager.LoadScene("SampleScene");
    }
}

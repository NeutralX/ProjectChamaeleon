using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitWinTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator waitWinTime()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameScene");

    }
}

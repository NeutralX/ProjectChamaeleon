using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI bestTimeText;
    private float startTime;
    private bool finish = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        bestTimeText.text = "BEST: " + GetBestTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (finish)
            return;

        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

    public void Finish()
    {
        finish = true;
        timerText.color = Color.yellow;
        string[] words = timerText.text.Split(':');
        string[] wordsBest = GetBestTime().Split(':');
        if (int.Parse(words[0]) < int.Parse(wordsBest[0]))
        {
            SaveTime(timerText.text);
        }
        else if (int.Parse(words[0]) == int.Parse(wordsBest[0]))
        {
            if (float.Parse(words[1]) < float.Parse(wordsBest[1]))
            {
                SaveTime(timerText.text);
            }
        } else if(int.Parse(wordsBest[0]) == 0 && float.Parse(wordsBest[1]) == 00.00f)
        {
            SaveTime(timerText.text);
        }
        
    }

    public string GetBestTime()
    {
        return PlayerPrefs.GetString("BestTime", "0:00,00");
    }

    public void SaveTime(string currentTime)
    {
        PlayerPrefs.SetString("BestTime", currentTime);
    }
}
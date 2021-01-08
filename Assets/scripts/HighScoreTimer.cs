using System;
using TMPro;
using UnityEngine;

public class HighScoreTimer : MonoBehaviour
{
    public GameObject recentScoreObject;
    public ScoreSheet scoreSheet;

    private float timer;
    private float time;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            timer = 0f;
            time += 1;
            GetComponent<TextMeshProUGUI>().text = time.ToString();
        }
    }

    public void ResetTimer()
    {
        time = 0f;
    }

    public void SaveHighScore()
    {
        var score = (int)Math.Ceiling(time);
        if (score > scoreSheet.highScore)
        {
            scoreSheet.highScore = score;
        }
        recentScoreObject.GetComponent<TextMeshProUGUI>().text = time.ToString();
    }
}

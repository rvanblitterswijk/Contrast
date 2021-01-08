using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    public ScoreSheet scoreSheet; 

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = scoreSheet.highScore.ToString();
    }
}

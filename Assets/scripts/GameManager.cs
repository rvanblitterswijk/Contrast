using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject timer;
    public GameObject lifeBar;
    public GameObject startButton;
    public GameObject playerKill;
    public GameObject tutorialButton;
    public GameObject tutorialScreen;
    public GameObject highScoreTimer;
    public GameObject scoreDisplays;

    void Start()
    {
        player.SetActive(false);
        timer.SetActive(false);
        lifeBar.SetActive(false);
        startButton.SetActive(true);
        tutorialScreen.SetActive(false);
        highScoreTimer.SetActive(false);
    }

    public void PlayGame()
    {
        tutorialScreen.SetActive(false);
        player.SetActive(true);
        timer.SetActive(true);
        lifeBar.SetActive(true);
        startButton.SetActive(false);
        tutorialButton.SetActive(false);
        ResetPositionTimerAndHealth();
        scoreDisplays.SetActive(false);
        highScoreTimer.SetActive(true);
        highScoreTimer.GetComponent<HighScoreTimer>().ResetTimer();
    }

    private void ResetPositionTimerAndHealth()
    {
        player.transform.position = new Vector2(0f, 0f);
        lifeBar.GetComponentInChildren<LifeBar>().FullHeal();
        timer.GetComponentInChildren<GameStateHandler>().ResetTimer();
    }

    public void TutorialScreen()
    {
        highScoreTimer.SetActive(false);
        startButton.SetActive(false);
        tutorialButton.SetActive(false);
        scoreDisplays.SetActive(false);
        tutorialScreen.SetActive(true);
    }

    public void OpenMenu()
    {
        tutorialScreen.SetActive(false);
        DestroyAllGhosts();
        KillPlayer();
        highScoreTimer.GetComponent<HighScoreTimer>().SaveHighScore();
        highScoreTimer.SetActive(false);
        timer.SetActive(false);
        lifeBar.SetActive(false);
        startButton.SetActive(true);
        tutorialButton.SetActive(true);
        scoreDisplays.SetActive(true);
    }

    public void ReturnToMenu()
    {
        tutorialScreen.SetActive(false);
        DestroyAllGhosts(); 
        timer.SetActive(false);
        lifeBar.SetActive(false);
        startButton.SetActive(true);
        tutorialButton.SetActive(true);
        scoreDisplays.SetActive(true);
    }

    private void KillPlayer()
    {
        Instantiate(playerKill, player.transform.position, playerKill.transform.rotation);
        player.SetActive(false);
    }

    private static void DestroyAllGhosts()
    {
        var ghosts = FindObjectsOfType<Ghost>();
        foreach (var ghost in ghosts)
        {
            ghost.Hit();
        }
    }
}

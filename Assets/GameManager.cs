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

    void Start()
    {
        player.SetActive(false);
        timer.SetActive(false);
        lifeBar.SetActive(false);
        startButton.SetActive(true);
        tutorialScreen.SetActive(false);
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
    }

    private void ResetPositionTimerAndHealth()
    {
        player.transform.position = new Vector2(0f, 0f);
        lifeBar.GetComponentInChildren<LifeBar>().FullHeal();
        timer.GetComponentInChildren<GameStateHandler>().ResetTimer();
    }

    public void TutorialScreen()
    {
        startButton.SetActive(false);
        tutorialButton.SetActive(false);
        tutorialScreen.SetActive(true);
    }

    public void OpenMenu()
    {
        tutorialScreen.SetActive(false);
        DestroyAllGhosts();
        KillPlayer();
        timer.SetActive(false);
        lifeBar.SetActive(false);
        startButton.SetActive(true);
        tutorialButton.SetActive(true);
    }

    public void ReturnToMenu()
    {
        tutorialScreen.SetActive(false);
        DestroyAllGhosts(); 
        timer.SetActive(false);
        lifeBar.SetActive(false);
        startButton.SetActive(true);
        tutorialButton.SetActive(true);
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

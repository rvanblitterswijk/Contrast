using UnityEngine;
using UnityEngine.UI;

public class GameStateHandler : MonoBehaviour
{
    private Image image;
    private int iterations;
    public State state;
    private Platform[] platforms;
    private float secondTimer;

    void Start()
    {
        image = GetComponent<Image>();
        platforms = FindObjectsOfType<Platform>();
        state = State.White;
        StateChange();
    }

    void Update()
    {
        secondTimer += Time.deltaTime;
        if (secondTimer > 1)
        {
            secondTimer = 0f;
            Tick();
        }
    }

    private void Tick()
    {
        iterations++;
        if (iterations >= 20)
        {

            image.fillAmount = 1f;
            StateChange();

            iterations = 0;
        }
        else
        {
            image.fillAmount = (float)(1f - (iterations * 0.05));
        }
    }

    private void StateChange()
    {
        var ghosts = FindObjectsOfType<Ghost>();
        if (state == State.White)
        {
            image.color = Color.black;
            state = State.Black;
            foreach (var platform in platforms)
            {
                platform.SignalState(State.Black);
            }
            foreach (var ghost in ghosts)
            {
                ghost.SignalState(State.Black);
            }
        } 
        else
        {
            image.color = Color.white;
            state = State.White;
            foreach (var platform in platforms)
            {
                platform.SignalState(State.White);
            }
            foreach (var ghost in ghosts)
            {
                ghost.SignalState(State.White);
            }
        }
    }
}

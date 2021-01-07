using UnityEngine;

public class Platform : MonoBehaviour
{
    public State state;


    public Collider2D polygonCollider2D;

    private void Start()
    {
    }

    public void SignalState(State state)
    {
        if (state == this.state)
        {
            EnablePlatform();
        } else
        {
            DisablePlatform();
        }
    }

    private void EnablePlatform()
    {
        polygonCollider2D.enabled = true;
    }

    private void DisablePlatform()
    {
        polygonCollider2D.enabled = false;
    }
}

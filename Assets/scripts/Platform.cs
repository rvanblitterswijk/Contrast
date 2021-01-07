using UnityEngine;

public class Platform : MonoBehaviour
{
    public State state;

    public Collider2D polygonCollider2D;

    private void Start()
    {
        //polygonCollider2D = GetComponent<Collider2D>();
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
        polygonCollider2D.isTrigger = false;
    }

    private void DisablePlatform()
    {
        polygonCollider2D.isTrigger = true;
    }
}

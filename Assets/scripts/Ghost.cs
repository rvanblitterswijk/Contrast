using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float travelSpeed;
    public State state;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    private bool aggressive;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (aggressive)
        {
            FlyTowardsPlayer();
        }
    }

    private void FlyTowardsPlayer()
    {
        var direction = (Vector2)(FindObjectOfType<B>().transform.position - transform.position);
        direction.Normalize();

        rigidbody2D.velocity = direction * travelSpeed;
    }

    public void SignalState(State state)
    {
        if (state == this.state)
        {
            aggressive = true;
            spriteRenderer.sortingOrder = 1;
        } 
        else
        {
            rigidbody2D.velocity = new Vector2(0f, 0f);

            spriteRenderer.sortingOrder = 0;
        }
    }

    public void Hit()
    {
        DestroySelf();
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}

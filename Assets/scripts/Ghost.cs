using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float travelSpeed;
    public State state;
    public ParticleSystem ghostKill;
    public bool aggressive;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private GameStateHandler gameStateHandler;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        aggressive = FindObjectOfType<GameStateHandler>().state == state;
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
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        } 
        else
        {
            aggressive = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }

    public void Hit()
    {
        var ghostKill = Instantiate(this.ghostKill, transform.position, this.ghostKill.transform.rotation);
        if (state == State.Black)
        {
            ghostKill.startColor = Color.black;

        }
        DestroySelf();
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}

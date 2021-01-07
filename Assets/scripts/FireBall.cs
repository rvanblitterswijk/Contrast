using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float travelSpeed;
    public float maxLifetime;

    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        FlyTowardsCursor();
        Destroy(gameObject, maxLifetime);
    }

    void Update()
    {
        
    }

    private void FlyTowardsCursor()
    {
        var direction = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        direction.Normalize();

        transform.right = direction;
        rigidbody2D.velocity = direction * travelSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("platform") && !collision.collider.isTrigger)
        {
            DestroySelf();
        } else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("ghost"))
        {
            collision.collider.gameObject.GetComponent<Ghost>().Hit();
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}


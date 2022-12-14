using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int health = 10;
    public int Health
    {
        get => health;
        set 
        {
            health = value;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private const float force = 25;
    private Vector2 LastVelocity { get; set; }
    private Rigidbody2D Rigidbody { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = FindObjectOfType<Player>().transform.position;
        Rigidbody.velocity = Player.Velocity.normalized * force;

        Destroy(gameObject, 2.0f);
    }

    private void Update()
    {
        LastVelocity = Rigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float speed = LastVelocity.magnitude;

        Vector2 direction = Vector2.Reflect(LastVelocity.normalized, collision.contacts[0].normal);
        Rigidbody.velocity = direction * Mathf.Max(speed, 0);

        Health--;
    }
}

using System;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    private int health;
    private int Health
    {
        get => health;
        set
        {
            health = value;
            TextComponent.text = $"{health}";

            if(health <= 0)
            {
                TextComponent.enabled = false;
                GetComponent<Rigidbody2D>().isKinematic = false;
                GetComponent<BoxCollider2D>().enabled = false;
                Destroy(gameObject, 2.0f);
            }
        }
    }

    private Animation Animation { get; set; }

    private TextMeshPro TextComponent { get; set; }

    public static Action OnCollisionEnter { get; set; }

    private void Start()
    {
        Animation = GetComponent<Animation>();
        TextComponent = GetComponentInChildren<TextMeshPro>();
        Health = UnityEngine.Random.Range(1, 10);
    }

    public void MoveDown()
    {
        transform.position += Vector3.down * 0.6f;
    }

    private void OnCollisionEnter2D()
    {
        if (Animation.isPlaying)
        {
            Animation.Stop();
        }

        Animation.Play();
        OnCollisionEnter?.Invoke();

        Health--;
    }
}

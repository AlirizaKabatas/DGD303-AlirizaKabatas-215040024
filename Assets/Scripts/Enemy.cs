using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Meteor"))
        {
            TakeDamage(2); 
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die(); 
        }
    }

    void Die()
    {
        Destroy(gameObject); 
    }
}

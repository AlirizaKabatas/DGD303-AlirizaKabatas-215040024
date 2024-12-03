using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2; // Düþmanýn baþlangýç saðlýðý

    void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer çarpan obje lazer ise
        if (other.CompareTag("PlayerBullet"))
        {
            TakeDamage(1); // 1 hasar al
            Destroy(other.gameObject); // Lazer yok edilir
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage; // Saðlýðý azalt

        if (health <= 0)
        {
            Die(); // Saðlýk sýfýra ulaþýrsa yok ol
        }
    }

    void Die()
    {
        Destroy(gameObject); // Düþmaný yok et
        // Buraya patlama efekti veya ses ekleyebilirsiniz
    }
}

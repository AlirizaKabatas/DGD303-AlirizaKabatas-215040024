using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10; // Oyuncunun baþlangýç saðlýðý

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meteor"))
        {
            TakeDamage(10); // Meteordan 10 hasar al
        }
        else if (other.CompareTag("EnemyBullet"))
        {
            TakeDamage(3); // Düþman mermisinden 4 hasar al
            Destroy(other.gameObject); // Mermiyi yok et
        }
        else if (other.CompareTag("EnemyMisille"))
        {
            TakeDamage(10); // Düþman mermisinden 4 hasar al
            Destroy(other.gameObject); // Mermiyi yok et
        }
        else if (other.CompareTag("BossBullet"))
        {
            TakeDamage(4); // Düþman mermisinden 4 hasar al
            Destroy(other.gameObject); // Mermiyi yok et
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage; // Saðlýðý azalt

        if (health <= 0)
        {
            Die(); // Saðlýk sýfýra ulaþýrsa öl
        }
    }

    void Die()
    {
        Destroy(gameObject); // Oyuncuyu yok et

        GameOver();
    }

    void GameOver()
    {
        // Ayný sahneyi yeniden yükle (Game Over)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

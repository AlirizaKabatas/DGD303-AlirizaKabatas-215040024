using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10; // Oyuncunun ba�lang�� sa�l���

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meteor"))
        {
            TakeDamage(10); // Meteordan 10 hasar al
        }
        else if (other.CompareTag("EnemyBullet"))
        {
            TakeDamage(3); // D��man mermisinden 4 hasar al
            Destroy(other.gameObject); // Mermiyi yok et
        }
        else if (other.CompareTag("EnemyMisille"))
        {
            TakeDamage(10); // D��man mermisinden 4 hasar al
            Destroy(other.gameObject); // Mermiyi yok et
        }
        else if (other.CompareTag("BossBullet"))
        {
            TakeDamage(4); // D��man mermisinden 4 hasar al
            Destroy(other.gameObject); // Mermiyi yok et
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage; // Sa�l��� azalt

        if (health <= 0)
        {
            Die(); // Sa�l�k s�f�ra ula��rsa �l
        }
    }

    void Die()
    {
        Destroy(gameObject); // Oyuncuyu yok et

        GameOver();
    }

    void GameOver()
    {
        // Ayn� sahneyi yeniden y�kle (Game Over)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

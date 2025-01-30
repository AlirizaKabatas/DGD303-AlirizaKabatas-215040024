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
            TakeDamage(3); 
            Destroy(other.gameObject); // Mermiyi yok et
        }
        else if (other.CompareTag("EnemyMisille"))
        {
            TakeDamage(10);
            Destroy(other.gameObject); // Mermiyi yok et
        }
        else if (other.CompareTag("BossBullet"))
        {
            TakeDamage(4);
            Destroy(other.gameObject); // Mermiyi yok et
        }
        else if (other.CompareTag("BossBullet2"))
        {
            TakeDamage(6);
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

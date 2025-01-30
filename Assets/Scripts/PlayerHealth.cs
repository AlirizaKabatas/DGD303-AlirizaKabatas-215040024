using UnityEngine;
using TMPro; // TextMeshPro için gerekli namespace
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 50; // Oyuncunun baþlangýç saðlýðý
    public int maxHealth = 50; // Maksimum saðlýk
    public TextMeshProUGUI healthText; // TextMeshPro için referans

    void Start()
    {
        // Ýlk baþta saðlýk bilgisini güncelle
        UpdateHealthText();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meteor"))
        {
            TakeDamage(10); // Meteordan 10 hasar al
        }
        else if (other.CompareTag("EnemyBullet"))
        {
            TakeDamage(2);
            Destroy(other.gameObject); // Mermiyi yok et
        }
        else if (other.CompareTag("EnemyMisille"))
        {
            TakeDamage(10);
            Destroy(other.gameObject); // Mermiyi yok et
        }
        else if (other.CompareTag("BossBullet"))
        {
            TakeDamage(3);
            Destroy(other.gameObject); // Mermiyi yok et
        }
        else if (other.CompareTag("BossBullet2"))
        {
            TakeDamage(5);
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

        // Saðlýk deðiþtiðinde metni güncelle
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        // Saðlýk bilgisi TextMeshPro'ya yazdýrýlýyor
        if (healthText != null)
        {
            healthText.text = "HP: " + health.ToString(); // HP: 50 þeklinde yazdýrýlacak
        }
    }

    void Die()
    {
        Destroy(gameObject); // Oyuncuyu yok et

        GameOver(); // Oyuncu öldü, GameOver iþlevi çaðrýlacak
    }

    void GameOver()
    {
        // Oyuncu öldü ve oyunun bitmesini istemiyorsunuz, EscMenu sahnesine geçiþ yapalým
        SceneManager.LoadScene("EscMenu"); // EscMenu sahnesine geçiþ yap
    }
}

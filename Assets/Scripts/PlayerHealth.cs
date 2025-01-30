using UnityEngine;
using TMPro; // TextMeshPro i�in gerekli namespace
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 50; // Oyuncunun ba�lang�� sa�l���
    public int maxHealth = 50; // Maksimum sa�l�k
    public TextMeshProUGUI healthText; // TextMeshPro i�in referans

    void Start()
    {
        // �lk ba�ta sa�l�k bilgisini g�ncelle
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
        health -= damage; // Sa�l��� azalt

        if (health <= 0)
        {
            Die(); // Sa�l�k s�f�ra ula��rsa �l
        }

        // Sa�l�k de�i�ti�inde metni g�ncelle
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        // Sa�l�k bilgisi TextMeshPro'ya yazd�r�l�yor
        if (healthText != null)
        {
            healthText.text = "HP: " + health.ToString(); // HP: 50 �eklinde yazd�r�lacak
        }
    }

    void Die()
    {
        Destroy(gameObject); // Oyuncuyu yok et

        GameOver(); // Oyuncu �ld�, GameOver i�levi �a�r�lacak
    }

    void GameOver()
    {
        // Oyuncu �ld� ve oyunun bitmesini istemiyorsunuz, EscMenu sahnesine ge�i� yapal�m
        SceneManager.LoadScene("EscMenu"); // EscMenu sahnesine ge�i� yap
    }
}

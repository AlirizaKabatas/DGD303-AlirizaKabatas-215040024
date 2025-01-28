using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2; // D��man can�
    public Animator animator; // �l�m animasyonu i�in Animator
    public AudioClip deathSound; // �l�m sesi i�in ses klibi
    public AudioSource audioSource; // Ses �almak i�in AudioSource

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
        // Animasyonu oynat
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        // �l�m sesini �al
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        // Animasyonun tamamlanmas�n� beklemek i�in nesneyi yok etmeyi geciktirebilirsiniz
        Destroy(gameObject, 1f); // 1 saniye sonra nesneyi yok et
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2; // Düþman caný
    public Animator animator; // Ölüm animasyonu için Animator
    public AudioClip deathSound; // Ölüm sesi için ses klibi
    public AudioSource audioSource; // Ses çalmak için AudioSource

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

        // Ölüm sesini çal
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        // Animasyonun tamamlanmasýný beklemek için nesneyi yok etmeyi geciktirebilirsiniz
        Destroy(gameObject, 1f); // 1 saniye sonra nesneyi yok et
    }
}

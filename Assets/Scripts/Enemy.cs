using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2; // Düþman caný
    public AudioClip deathSound; // Ölüm sesi
    public AudioSource audioSource; // Ses çalmak için AudioSource
    public bool isBoss = false; // Boss olup olmadýðýný belirler
    public GameObject bossCanvas; // Boss öldüðünde gösterilecek Canvas

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
        Debug.Log("Enemy öldü, ses çalýnmalý!");

        // Düþmaný görünmez yap
        SetVisibility(false);

        // Ölüm sesini çal
        float destroyDelay = 1f; // Varsayýlan yok etme süresi
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
            Debug.Log("Ölüm sesi oynatýlýyor!");
            destroyDelay = deathSound.length; // Ses uzunluðu kadar beklet
        }

        // Eðer boss ise canvas aç
        if (isBoss && bossCanvas != null)
        {
            bossCanvas.SetActive(true);
        }

        // Objeyi belirlenen süre sonunda yok et (sesin uzunluðuna göre)
        Destroy(gameObject, destroyDelay);
    }

    void SetVisibility(bool isVisible)
    {
        // Tüm Renderer bileþenlerini devre dýþý býrak veya etkinleþtir
        foreach (var renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = isVisible;
        }

        // Eðer Collider varsa, onu da devre dýþý býrak
        var collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = isVisible;
        }
    }
}
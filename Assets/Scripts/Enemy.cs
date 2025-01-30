using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2; // D��man can�
    public AudioClip deathSound; // �l�m sesi
    public AudioSource audioSource; // Ses �almak i�in AudioSource
    public bool isBoss = false; // Boss olup olmad���n� belirler
    public GameObject bossCanvas; // Boss �ld���nde g�sterilecek Canvas

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
        Debug.Log("Enemy �ld�, ses �al�nmal�!");

        // D��man� g�r�nmez yap
        SetVisibility(false);

        // �l�m sesini �al
        float destroyDelay = 1f; // Varsay�lan yok etme s�resi
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
            Debug.Log("�l�m sesi oynat�l�yor!");
            destroyDelay = deathSound.length; // Ses uzunlu�u kadar beklet
        }

        // E�er boss ise canvas a�
        if (isBoss && bossCanvas != null)
        {
            bossCanvas.SetActive(true);
        }

        // Objeyi belirlenen s�re sonunda yok et (sesin uzunlu�una g�re)
        Destroy(gameObject, destroyDelay);
    }

    void SetVisibility(bool isVisible)
    {
        // T�m Renderer bile�enlerini devre d��� b�rak veya etkinle�tir
        foreach (var renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = isVisible;
        }

        // E�er Collider varsa, onu da devre d��� b�rak
        var collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = isVisible;
        }
    }
}
using UnityEngine;

public class LazerShoot : MonoBehaviour
{
    public GameObject lazerPrefab; // Lazer prefab'�
    public Transform lazerSpawnPoint; // Lazerin ��k�� noktas�
    public float lazerSpeed = 10f; // Lazerin h�z�
    public float fireRate = 0.5f; // Ate� etme h�z� (0.5 saniyede bir)

    public AudioClip fireSound; // Ate� sesi
    private AudioSource audioSource; // Ses kayna��

    private float nextFireTime = 0f; // Bir sonraki at���n zaman�

    void Start()
    {
        // AudioSource bile�enini al
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Mouse 1'e t�klama ve fire rate kontrol�
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            ShootLazer();
            nextFireTime = Time.time + fireRate; // Bir sonraki at�� zaman�n� belirle
        }
    }

    void ShootLazer()
    {
        // Lazer objesini spawn et
        GameObject lazer = Instantiate(lazerPrefab, lazerSpawnPoint.position, lazerSpawnPoint.rotation);

        // Lazerin Rigidbody2D'sine h�z uygula
        Rigidbody2D rb = lazer.GetComponent<Rigidbody2D>();
        rb.velocity = lazer.transform.up * lazerSpeed; // Lazer kendi local Y ekseninde hareket eder

        // 5 saniye sonra lazeri yok et
        Destroy(lazer, 5f);

        // Ate� sesini �al
        if (audioSource != null && fireSound != null)
        {
            audioSource.PlayOneShot(fireSound);
        }
    }
}

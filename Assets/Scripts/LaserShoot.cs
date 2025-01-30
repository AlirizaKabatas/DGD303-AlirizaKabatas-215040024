using UnityEngine;

public class LazerShoot : MonoBehaviour
{
    public GameObject lazerPrefab; // Lazer prefab'ý
    public Transform lazerSpawnPoint; // Lazerin çýkýþ noktasý
    public float lazerSpeed = 10f; // Lazerin hýzý
    public float fireRate = 0.5f; // Ateþ etme hýzý (0.5 saniyede bir)

    public AudioClip fireSound; // Ateþ sesi
    private AudioSource audioSource; // Ses kaynaðý

    private float nextFireTime = 0f; // Bir sonraki atýþýn zamaný

    void Start()
    {
        // AudioSource bileþenini al
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Mouse 1'e týklama ve fire rate kontrolü
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            ShootLazer();
            nextFireTime = Time.time + fireRate; // Bir sonraki atýþ zamanýný belirle
        }
    }

    void ShootLazer()
    {
        // Lazer objesini spawn et
        GameObject lazer = Instantiate(lazerPrefab, lazerSpawnPoint.position, lazerSpawnPoint.rotation);

        // Lazerin Rigidbody2D'sine hýz uygula
        Rigidbody2D rb = lazer.GetComponent<Rigidbody2D>();
        rb.velocity = lazer.transform.up * lazerSpeed; // Lazer kendi local Y ekseninde hareket eder

        // 5 saniye sonra lazeri yok et
        Destroy(lazer, 5f);

        // Ateþ sesini çal
        if (audioSource != null && fireSound != null)
        {
            audioSource.PlayOneShot(fireSound);
        }
    }
}

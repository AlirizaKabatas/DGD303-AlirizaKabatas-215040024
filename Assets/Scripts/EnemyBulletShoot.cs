using UnityEngine;

public class EnemyBulletShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab'�
    public Transform[] bulletSpawnPoints; // Merminin ��k�� noktalar� dizisi
    public float bulletSpeed = 5f; // Merminin h�z�
    public float fireRate = 2f; // Ate� etme aral��� (saniye cinsinden)
    public float fireCooldown; // Ate� zamanlamas� i�in cooldown

    void Update()
    {
        // Ate� zaman�n� kontrol et
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            ShootBullet(); // Mermi ate�le
            fireCooldown = fireRate; // Cooldown'u s�f�rla
        }
    }

    void ShootBullet()
    {
        // Rastgele bir mermi ��k�� noktas� se�
        Transform spawnPoint = bulletSpawnPoints[Random.Range(0, bulletSpawnPoints.Length)];

        // Mermi objesini spawn et
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        // Merminin Rigidbody2D'sine h�z uygula
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = -bullet.transform.up * bulletSpeed; // Mermi a�a�� do�ru hareket eder

        // Merminin otomatik yok olma s�resi
        Destroy(bullet, 5f);
    }
}

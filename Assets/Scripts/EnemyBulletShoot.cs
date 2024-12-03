using UnityEngine;

public class EnemyBulletShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab'�
    public Transform bulletSpawnPoint; // Merminin ��k�� noktas�
    public float bulletSpeed = 5f; // Merminin h�z�
    public float fireRate = 2f; // Ate� etme aral��� (saniye cinsinden)
    private float fireCooldown; // Ate� zamanlamas� i�in cooldown

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
        // Mermi objesini spawn et
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Merminin Rigidbody2D'sine h�z uygula
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = -bullet.transform.up * bulletSpeed; // Mermi a�a�� do�ru hareket eder

        // Merminin otomatik yok olma s�resi
        Destroy(bullet, 5f);
    }
}

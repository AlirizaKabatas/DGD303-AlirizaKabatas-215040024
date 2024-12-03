using UnityEngine;

public class EnemyBulletShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab'ý
    public Transform bulletSpawnPoint; // Merminin çýkýþ noktasý
    public float bulletSpeed = 5f; // Merminin hýzý
    public float fireRate = 2f; // Ateþ etme aralýðý (saniye cinsinden)
    private float fireCooldown; // Ateþ zamanlamasý için cooldown

    void Update()
    {
        // Ateþ zamanýný kontrol et
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            ShootBullet(); // Mermi ateþle
            fireCooldown = fireRate; // Cooldown'u sýfýrla
        }
    }

    void ShootBullet()
    {
        // Mermi objesini spawn et
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Merminin Rigidbody2D'sine hýz uygula
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = -bullet.transform.up * bulletSpeed; // Mermi aþaðý doðru hareket eder

        // Merminin otomatik yok olma süresi
        Destroy(bullet, 5f);
    }
}

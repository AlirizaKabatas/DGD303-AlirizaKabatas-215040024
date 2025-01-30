using UnityEngine;
using System.Collections;

public class EnemyBulletShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab'�
    public Transform[] bulletSpawnPoints; // Mermi ��k�� noktalar�
    public float bulletSpeed = 5f; // Mermi h�z�
    public float fireRate = 2f; // Normal ate� aral���
    public float fireCooldown; // Normal ate� i�in cooldown
    public float ultiCooldown = 8f; // Ulti s�resi
    public int ultiShots = 3; // Ulti s�ras�nda ka� kez ate� edecek
    public float ultiShotInterval = 1f; // Ulti s�ras�nda at��lar aras� s�re

    private bool isUltiActive = false; // Ulti aktif mi?
    private float ultiTimer = 0f; // Ulti i�in zamanlay�c�

    void Update()
    {
        ultiTimer += Time.deltaTime;
        fireCooldown -= Time.deltaTime;

        if (ultiTimer >= ultiCooldown)
        {
            StartCoroutine(UltiAttack());
            ultiTimer = 0f;
        }

        if (!isUltiActive && fireCooldown <= 0f)
        {
            ShootBullet();
            fireCooldown = fireRate;
        }
    }

    void ShootBullet()
    {
        Transform spawnPoint = bulletSpawnPoints[Random.Range(0, bulletSpawnPoints.Length)];
        Fire(spawnPoint);
    }

    IEnumerator UltiAttack()
    {
        isUltiActive = true;

        for (int i = 0; i < ultiShots; i++)
        {
            foreach (Transform spawnPoint in bulletSpawnPoints)
            {
                Fire(spawnPoint);
            }
            yield return new WaitForSeconds(ultiShotInterval);
        }

        isUltiActive = false;
    }

    void Fire(Transform spawnPoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = -spawnPoint.up * bulletSpeed;
        Destroy(bullet, 5f);
    }
}

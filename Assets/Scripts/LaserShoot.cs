using UnityEngine;

public class LazerShoot : MonoBehaviour
{
    public GameObject lazerPrefab; // Lazer prefab'ý
    public Transform lazerSpawnPoint; // Lazerin çýkýþ noktasý
    public float lazerSpeed = 10f; // Lazerin hýzý

    void Update()
    {
        // Mouse 1'e týklama
        if (Input.GetMouseButtonDown(0))
        {
            ShootLazer();
        }

    }

    void ShootLazer()
    {
        // Lazer objesini spawn et
        GameObject lazer = Instantiate(lazerPrefab, lazerSpawnPoint.position, lazerSpawnPoint.rotation);

        // Lazerin Rigidbody2D'sine hýz uygula
        Rigidbody2D rb = lazer.GetComponent<Rigidbody2D>();
        rb.velocity = lazer.transform.up * lazerSpeed; // Lazer kendi local Y ekseninde hareket eder
        Destroy(lazer, 5f);
        // Lazerin otomatik yok olma süresi kaldýrýldý
        // Destroy(lazer, 5f);  // Bu satýrý kaldýrdýk
    }

}

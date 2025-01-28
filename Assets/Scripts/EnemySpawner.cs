using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Spawnlanacak düþman prefab'ý
    public Transform[] spawnPoints; // Spawn noktalarý
    public int maxEnemyCount = 3; // Maksimum spawnlanacak düþman sayýsý
    public float spawnInterval = 5f; // Her bir düþman arasýndaki spawn süresi (saniye)
    public float totalSpawnDuration = 15f; // Kaç saniye boyunca düþman spawnlanacak

    private float spawnTimer = 0f; // Spawn için zamanlayýcý
    private float elapsedTime = 0f; // Toplam geçen süre
    private int spawnedEnemyCount = 0; // Þu ana kadar spawnlanan düþman sayýsý

    void Update()
    {
        // Eðer süreyi geçmediyse ve daha az düþman varsa spawn iþlemine devam et
        if (spawnedEnemyCount < maxEnemyCount)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0f; // Zamanlayýcýyý sýfýrla
            }
        }
    }

    void SpawnEnemy()
    {
        // Rastgele bir spawn noktasý seç
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Spawn edilen düþmaný oluþtur
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); // spawn noktasýndaki rotayý kullan

        // Düþmaný Z ekseninde 180 derece döndür
        newEnemy.transform.rotation = Quaternion.Euler(0, 0, 180);  // Z ekseninde 180 derece döndür

        spawnedEnemyCount++; // Spawnlanan düþman sayýsýný artýr
    }
}

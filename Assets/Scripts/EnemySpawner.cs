using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Spawnlanacak d��man prefab'�
    public Transform[] spawnPoints; // Spawn noktalar�
    public int maxEnemyCount = 3; // Maksimum spawnlanacak d��man say�s�
    public float spawnInterval = 5f; // Her bir d��man aras�ndaki spawn s�resi (saniye)
    public float totalSpawnDuration = 15f; // Ka� saniye boyunca d��man spawnlanacak

    private float spawnTimer = 0f; // Spawn i�in zamanlay�c�
    private float elapsedTime = 0f; // Toplam ge�en s�re
    private int spawnedEnemyCount = 0; // �u ana kadar spawnlanan d��man say�s�

    void Update()
    {
        // E�er s�reyi ge�mediyse ve daha az d��man varsa spawn i�lemine devam et
        if (spawnedEnemyCount < maxEnemyCount)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0f; // Zamanlay�c�y� s�f�rla
            }
        }
    }

    void SpawnEnemy()
    {
        // Rastgele bir spawn noktas� se�
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Spawn edilen d��man� olu�tur
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); // spawn noktas�ndaki rotay� kullan

        // D��man� Z ekseninde 180 derece d�nd�r
        newEnemy.transform.rotation = Quaternion.Euler(0, 0, 180);  // Z ekseninde 180 derece d�nd�r

        spawnedEnemyCount++; // Spawnlanan d��man say�s�n� art�r
    }
}

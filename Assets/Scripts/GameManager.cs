using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerHealth = 3; // Oyuncu caný
    public int enemyHealth = 3; // Düþman caný

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerTakeDamage()
    {
        playerHealth--;
        if (playerHealth <= 0)
        {
            GameOver();
        }
    }

    public void EnemyTakeDamage(EnemyShipMini enemy)
    {
        enemyHealth--;
        if (enemyHealth <= 0)
        {
            Destroy(enemy.gameObject);
        }
    }

    void GameOver()
    {
        Debug.Log("Oyun Bitti!");
        // Oyun bitiþ ekraný ekle
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public string nextSceneName; // Sonraki sahnenin ad� (Inspector'dan ayarla)
    private Enemy enemy; // Enemy koduna eri�im

    void Start()
    {
        enemy = GetComponent<Enemy>(); // Ayn� objedeki Enemy scriptini al
    }

    void Update()
    {
        // Enemy'nin can� 0 olduysa boss �ld� demektir
        if (enemy != null && enemy.health <= 0)
        {
            Invoke("LoadNextScene", 2f); // 2 saniye sonra sahneyi y�kle
        }
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}

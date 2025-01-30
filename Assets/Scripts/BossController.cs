using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public string nextSceneName; // Sonraki sahnenin adý (Inspector'dan ayarla)
    private Enemy enemy; // Enemy koduna eriþim

    void Start()
    {
        enemy = GetComponent<Enemy>(); // Ayný objedeki Enemy scriptini al
    }

    void Update()
    {
        // Enemy'nin caný 0 olduysa boss öldü demektir
        if (enemy != null && enemy.health <= 0)
        {
            Invoke("LoadNextScene", 2f); // 2 saniye sonra sahneyi yükle
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

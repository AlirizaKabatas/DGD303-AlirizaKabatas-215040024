using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    // Singleton pattern
    public static SceneTransitionManager Instance;

    public string nextSceneName; // Sahne ismini burada tutuyoruz

    void Awake()
    {
        // Eðer zaten bir instance varsa, kendini siler
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Yeni sahnelere geçildiðinde bu objenin yok olmasýný engelle
        }
    }

    public void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log("Yeni sahne yükleniyor: " + nextSceneName);
            StartCoroutine(LoadSceneAfterDelay(2f)); // 2 saniye bekle, sonra sahneyi yükle
        }
        else
        {
            Debug.LogWarning("Sahne ismi boþ! Lütfen 'nextSceneName' deðiþkenini doldurduðunuzdan emin olun.");
        }
    }

    // Sahne geçiþini 2 saniye sonra yapacak coroutine
    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 2 saniye bekle
        SceneManager.LoadScene(nextSceneName); // Public deðiþken üzerinden sahne ismini alýp yükler
    }
}

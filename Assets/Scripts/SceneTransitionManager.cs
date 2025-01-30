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
        // E�er zaten bir instance varsa, kendini siler
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Yeni sahnelere ge�ildi�inde bu objenin yok olmas�n� engelle
        }
    }

    public void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log("Yeni sahne y�kleniyor: " + nextSceneName);
            StartCoroutine(LoadSceneAfterDelay(2f)); // 2 saniye bekle, sonra sahneyi y�kle
        }
        else
        {
            Debug.LogWarning("Sahne ismi bo�! L�tfen 'nextSceneName' de�i�kenini doldurdu�unuzdan emin olun.");
        }
    }

    // Sahne ge�i�ini 2 saniye sonra yapacak coroutine
    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 2 saniye bekle
        SceneManager.LoadScene(nextSceneName); // Public de�i�ken �zerinden sahne ismini al�p y�kler
    }
}

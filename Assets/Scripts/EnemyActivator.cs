using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    public float activationDelay = 10f; // Baþlangýçta bekleme süresi
    private bool isActive = false; // Enemy'nin aktif olup olmadýðý
    private Collider2D enemyCollider; // Enemy collider
    private Renderer enemyRenderer; // Enemy renderer

    private EnemyShipMini enemyShipMini; // Enemy'nin hareket scripti (varsa)

    void Start()
    {
        // Componentleri al
        enemyCollider = GetComponent<Collider2D>();
        enemyRenderer = GetComponent<Renderer>();
        enemyShipMini = GetComponent<EnemyShipMini>();

        // Baþlangýçta hareket etmeyi engelle
        if (enemyCollider != null) enemyCollider.enabled = false; // Çarpýþma engellensin
        if (enemyRenderer != null) enemyRenderer.enabled = false; // Görünürlük engellensin

        // Baþlangýçta enemy'nin hareket etmesini engelle
        if (enemyShipMini != null) enemyShipMini.enabled = false;

        // Zamanlayýcýyý baþlat
        Invoke("ActivateEnemy", activationDelay); // Belirlenen süre sonunda aktif et
    }

    void ActivateEnemy()
    {
        // Enemy'yi aktif hale getir
        isActive = true;

        // Collider ve Renderer'ý etkinleþtir
        if (enemyCollider != null) enemyCollider.enabled = true;
        if (enemyRenderer != null) enemyRenderer.enabled = true;

        // Enemy'nin hareketini aktive et (varsa)
        if (enemyShipMini != null) enemyShipMini.enabled = true;
    }
}

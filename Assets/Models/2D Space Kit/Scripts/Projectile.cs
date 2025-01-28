using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject firing_ship; // Bu mermiyi kimin ateşlediğini takip etmek için

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Basit bir yok olma mantığı
        Destroy(gameObject);
    }
}

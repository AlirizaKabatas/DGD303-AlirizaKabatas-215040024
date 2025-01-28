using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float speed = 2f; // Geminin hýzý
    private Vector2 direction; // Hareket yönü
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChooseRandomDirection(); // Rastgele bir yön seç
    }

    private void Update()
    {
        rb.velocity = direction * speed; // Gemiyi hareket ettir
    }

    private void ChooseRandomDirection()
    {
        // Rastgele yukarý, aþaðý, sað veya sola yön seç
        int random = Random.Range(0, 4);
        switch (random)
        {
            case 0: direction = Vector2.up; break; // Yukarý
            case 1: direction = Vector2.down; break; // Aþaðý
            case 2: direction = Vector2.left; break; // Sola
            case 3: direction = Vector2.right; break; // Saða
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Çarpýþma sonrasý yeni rastgele yön seç
        ChooseRandomDirection();
    }
}

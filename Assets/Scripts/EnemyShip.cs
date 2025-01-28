using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float speed = 2f; // Geminin h�z�
    private Vector2 direction; // Hareket y�n�
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChooseRandomDirection(); // Rastgele bir y�n se�
    }

    private void Update()
    {
        rb.velocity = direction * speed; // Gemiyi hareket ettir
    }

    private void ChooseRandomDirection()
    {
        // Rastgele yukar�, a�a��, sa� veya sola y�n se�
        int random = Random.Range(0, 4);
        switch (random)
        {
            case 0: direction = Vector2.up; break; // Yukar�
            case 1: direction = Vector2.down; break; // A�a��
            case 2: direction = Vector2.left; break; // Sola
            case 3: direction = Vector2.right; break; // Sa�a
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �arp��ma sonras� yeni rastgele y�n se�
        ChooseRandomDirection();
    }
}

using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float moveSpeed = 0.005f; // Arka plan�n hareket h�z�
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position; // Ba�lang�� pozisyonu
    }

    private void Update()
    {
        // Arka plan� a�a�� do�ru sabit h�zla hareket ettir
        transform.position = new Vector2(startPosition.x, startPosition.y + Mathf.PingPong(Time.time * moveSpeed, 1));
    }
}

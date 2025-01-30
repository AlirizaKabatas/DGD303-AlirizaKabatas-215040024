using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float moveSpeed = 0.005f; // Arka planýn hareket hýzý
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position; // Baþlangýç pozisyonu
    }

    private void Update()
    {
        // Arka planý aþaðý doðru sabit hýzla hareket ettir
        transform.position = new Vector2(startPosition.x, startPosition.y + Mathf.PingPong(Time.time * moveSpeed, 1));
    }
}

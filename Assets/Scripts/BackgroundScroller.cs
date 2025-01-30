using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.005f; // Arka plan�n hareket h�z�
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Background'� s�rekli a�a��ya kayd�r
        transform.position = new Vector3(startPosition.x, startPosition.y - Mathf.Repeat(Time.time * scrollSpeed, 1), startPosition.z);
    }
}

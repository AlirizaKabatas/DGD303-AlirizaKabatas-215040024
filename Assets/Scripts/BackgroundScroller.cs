using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.005f; // Arka planýn hareket hýzý
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Background'ý sürekli aþaðýya kaydýr
        transform.position = new Vector3(startPosition.x, startPosition.y - Mathf.Repeat(Time.time * scrollSpeed, 1), startPosition.z);
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hýzý
    public Vector2 screenBounds; // Ekran sýnýrlarý
    public Collider2D boundaryCollider; // Sýnýrlarý belirleyen collider (editörden atanacak)

    private Vector2 objectSize;

    void Start()
    {
        objectSize = GetComponent<SpriteRenderer>().bounds.extents; // Geminin boyutu
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        // WASD ile hareket
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 newPosition = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;

        // Yeni pozisyon hesapla ve sýnýrla
        Vector3 nextPosition = transform.position + (Vector3)newPosition;

        // Ekran sýnýrlarýyla oyuncuyu sýnýrlama
        nextPosition.x = Mathf.Clamp(nextPosition.x, -screenBounds.x + objectSize.x, screenBounds.x - objectSize.x);
        nextPosition.y = Mathf.Clamp(nextPosition.y, -screenBounds.y + objectSize.y, screenBounds.y - objectSize.y);

        // Collider sýnýrlarýyla oyuncuyu sýnýrla
        if (boundaryCollider != null)
        {
            Vector3 colliderMin = boundaryCollider.bounds.min;
            Vector3 colliderMax = boundaryCollider.bounds.max;

            nextPosition.x = Mathf.Clamp(nextPosition.x, colliderMin.x + objectSize.x, colliderMax.x - objectSize.x);
            nextPosition.y = Mathf.Clamp(nextPosition.y, colliderMin.y + objectSize.y, colliderMax.y - objectSize.y);
        }

        // Pozisyonu uygula
        transform.position = nextPosition;
    }
}

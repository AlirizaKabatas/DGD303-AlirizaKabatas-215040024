using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float moveSpeedX = 0f;
    public float moveSpeedY = -2f;
    public float rotateSpeed = 100f; 

    void Update()
    {

        transform.Translate(new Vector3(moveSpeedX, moveSpeedY, 0) * Time.deltaTime, Space.World);

        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        if (transform.position.x < -screenBounds.x - 1 || transform.position.x > screenBounds.x + 1 ||
            transform.position.y < -screenBounds.y - 1 || transform.position.y > screenBounds.y + 1)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Oyuncuya hasar ver
            GameManager.Instance.PlayerTakeDamage();
            Destroy(gameObject);
        }
    }
}

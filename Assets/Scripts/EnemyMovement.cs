using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints; // D��man�n gidece�i noktalar
    public float moveSpeed = 3f; // Hareket h�z�
    public float startDelay = 0f; // Ba�lamadan �nce bekleme s�resi
    private int currentWaypointIndex = 0; // �u anki hedef nokta
    private bool canMove = false; // Hareket ba�las�n m�?

    private void Start()
    {
        StartCoroutine(StartMovementAfterDelay());
    }

    private IEnumerator StartMovementAfterDelay()
    {
        yield return new WaitForSeconds(startDelay); // Ba�lamadan �nce bekle
        canMove = true; // Hareket etmeye ba�la
    }

    private void Update()
    {
        if (!canMove || waypoints.Length == 0) return; // Hareket etmeye ba�lamad�k�a veya waypoints bo�sa bir �ey yapma

        Transform targetWaypoint = waypoints[currentWaypointIndex]; // Hedef waypoint

        // Hedefe do�ru yumu�ak bir �ekilde hareket et
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        // E�er hedef noktaya ula�t�ysak, bir sonraki hedefe git
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Bir sonraki waypoint'e ge�
            currentWaypointIndex++;

            // E�er rotan�n sonuna geldiysek, geriye d�n�p d�ng�ye gir
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // Ba�lang�� noktas�na geri d�n
            }
        }
    }

    // Yeni waypoints seti almak i�in fonksiyon
    public void SetWaypoints(Transform[] newWaypoints)
    {
        waypoints = newWaypoints;
    }
}

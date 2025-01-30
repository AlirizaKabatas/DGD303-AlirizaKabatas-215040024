using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints; // Düþmanýn gideceði noktalar
    public float moveSpeed = 3f; // Hareket hýzý
    public float startDelay = 0f; // Baþlamadan önce bekleme süresi
    private int currentWaypointIndex = 0; // Þu anki hedef nokta
    private bool canMove = false; // Hareket baþlasýn mý?

    private void Start()
    {
        StartCoroutine(StartMovementAfterDelay());
    }

    private IEnumerator StartMovementAfterDelay()
    {
        yield return new WaitForSeconds(startDelay); // Baþlamadan önce bekle
        canMove = true; // Hareket etmeye baþla
    }

    private void Update()
    {
        if (!canMove || waypoints.Length == 0) return; // Hareket etmeye baþlamadýkça veya waypoints boþsa bir þey yapma

        Transform targetWaypoint = waypoints[currentWaypointIndex]; // Hedef waypoint

        // Hedefe doðru yumuþak bir þekilde hareket et
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        // Eðer hedef noktaya ulaþtýysak, bir sonraki hedefe git
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Bir sonraki waypoint'e geç
            currentWaypointIndex++;

            // Eðer rotanýn sonuna geldiysek, geriye dönüp döngüye gir
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // Baþlangýç noktasýna geri dön
            }
        }
    }

    // Yeni waypoints seti almak için fonksiyon
    public void SetWaypoints(Transform[] newWaypoints)
    {
        waypoints = newWaypoints;
    }
}

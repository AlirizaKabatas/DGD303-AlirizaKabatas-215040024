using UnityEngine;

public class EnemyShipMini : MonoBehaviour
{
    // Konumlar arasýnda geçiþ yapacak olan hedefler
    public Transform[] targetPositions; // Hedef pozisyonlar (konum1, konum2, vb.)
    public float speed = 1f;  // Geçiþin hýzý (ne kadar yavaþsa o kadar smooth olur)
    private int currentTargetIndex = 0; // Þu anki hedefin indexi
    private Transform currentTarget; // Þu anki hedef Transform
    private float lerpTime = 0f; // Lerp zamanlayýcý

    void Start()
    {
        // Ýlk hedefi baþlat
        if (targetPositions.Length > 0)
        {
            currentTarget = targetPositions[currentTargetIndex];
        }
    }

    void Update()
    {
        // Eðer hedef varsa, gemiyi ona doðru hareket ettir
        if (currentTarget != null)
        {
            MoveSmoothlyTowardsTarget();
        }
    }

    void MoveSmoothlyTowardsTarget()
    {
        // Lerp zamanýný artýr
        lerpTime += Time.deltaTime * speed;

        // Hedefe doðru yumuþak bir þekilde hareket et
        transform.position = Vector3.Lerp(transform.position, currentTarget.position, lerpTime);

        // Eðer hedefe ulaþýldýysa, bir sonraki hedefe geçiþ yap
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            // Sýradaki hedefin index'ini bul ve hedefi deðiþtir
            currentTargetIndex = (currentTargetIndex + 1) % targetPositions.Length;
            currentTarget = targetPositions[currentTargetIndex];

            // Lerp zamanlayýcýsýný sýfýrla
            lerpTime = 0f;
        }
    }
}

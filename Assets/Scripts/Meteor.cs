using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float moveSpeed = 5f; // Meteorun hareket hýzý
    public float rotationSpeed = 100f; // Meteorun dönüþ hýzý
    public bool rotate = true; // Meteor kendi ekseni etrafýnda dönecek mi?
    public float resetTime = 8f; // Hareket süresi (saniye cinsinden)
    public Vector3 startPosition; // Baþlangýç pozisyonu
    public Vector3 moveDirection = Vector3.left; // Hareket yönü

    private float timer; // Süreyi takip eden deðiþken

    void Start()
    {
        startPosition = transform.position; // Baþlangýç pozisyonunu kaydet
        timer = resetTime; // Zamanlayýcýyý baþlat
    }

    void Update()
    {
        // Meteorun hareketi
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

        // Meteorun dönüþü (isteðe baðlý)
        if (rotate)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        // Zamanlayýcýyý azalt
        timer -= Time.deltaTime;

        // Süre dolduysa meteoru sýfýrla
        if (timer <= 0)
        {
            ResetMeteor();
        }
    }

    void ResetMeteor()
    {
        transform.position = startPosition; // Pozisyonu sýfýrla
        timer = resetTime; // Zamanlayýcýyý sýfýrla
    }
}

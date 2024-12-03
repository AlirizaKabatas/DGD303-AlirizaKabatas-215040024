using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float moveSpeed = 5f; // Meteorun hareket h�z�
    public float rotationSpeed = 100f; // Meteorun d�n�� h�z�
    public bool rotate = true; // Meteor kendi ekseni etraf�nda d�necek mi?
    public float resetTime = 8f; // Hareket s�resi (saniye cinsinden)
    public Vector3 startPosition; // Ba�lang�� pozisyonu
    public Vector3 moveDirection = Vector3.left; // Hareket y�n�

    private float timer; // S�reyi takip eden de�i�ken

    void Start()
    {
        startPosition = transform.position; // Ba�lang�� pozisyonunu kaydet
        timer = resetTime; // Zamanlay�c�y� ba�lat
    }

    void Update()
    {
        // Meteorun hareketi
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

        // Meteorun d�n��� (iste�e ba�l�)
        if (rotate)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        // Zamanlay�c�y� azalt
        timer -= Time.deltaTime;

        // S�re dolduysa meteoru s�f�rla
        if (timer <= 0)
        {
            ResetMeteor();
        }
    }

    void ResetMeteor()
    {
        transform.position = startPosition; // Pozisyonu s�f�rla
        timer = resetTime; // Zamanlay�c�y� s�f�rla
    }
}

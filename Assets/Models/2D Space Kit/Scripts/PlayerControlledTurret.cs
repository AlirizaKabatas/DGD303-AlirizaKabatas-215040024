using UnityEngine;
using System.Collections;

public class PlayerControlledTurret : MonoBehaviour
{

    public GameObject weapon_prefab; // Ateş edilecek mermi prefab'ı
    public GameObject[] barrel_hardpoints; // Mermilerin çıkacağı noktalar
    public float turret_rotation_speed = 3f; // Turret'in dönüş hızı
    public float shot_speed; // Merminin hızı
    public float fireRate = 0.2f; // Ateş etme hızı (saniye cinsinden)
    private float nextFireTime = 0f; // Sonraki ateş etme zamanı
    int barrel_index = 0; // Sıradaki namlu indeksi

    // Update is called once per frame
    void Update()
    {

        // Turret'in fare pozisyonuna doğru dönmesi
        Vector2 turretPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = CustomPointer.pointerPosition - turretPosition;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f, turret_rotation_speed * Time.deltaTime)));

        // Ateş etme kontrolü
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime && barrel_hardpoints != null)
        {
            // Mermiyi ateşle
            GameObject bullet = (GameObject)Instantiate(weapon_prefab, barrel_hardpoints[barrel_index].transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * shot_speed);
            bullet.GetComponent<Projectile>().firing_ship = transform.parent.gameObject;

            // Sıradaki namluyu seç
            barrel_index++;
            if (barrel_index >= barrel_hardpoints.Length)
                barrel_index = 0;

            // Sonraki ateş zamanını ayarla
            nextFireTime = Time.time + fireRate;
        }
    }
}
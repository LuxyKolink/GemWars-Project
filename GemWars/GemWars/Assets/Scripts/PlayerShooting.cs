using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab de la bala
    public Transform firePoint;      // Punto desde donde se dispara
    public float bulletSpeed = 10f;  // Velocidad de la bala

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Dispara con la barra espaciadora
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar la bala en la posición y rotación del FirePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Obtener el Rigidbody2D de la bala
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Aplicar velocidad en la dirección del FirePoint
            rb.linearVelocity = firePoint.right * bulletSpeed;
        }
    }
}

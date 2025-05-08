using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float shootCooldown = 0.5f; // Tiempo mínimo entre disparos en segundos

    private float lastShootTime = -Mathf.Infinity; // Último instante en que se disparó

    void Update()
    {
        // Solo dispara si ha pasado suficiente tiempo desde el último disparo
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = firePoint.right * bulletSpeed;
        }
    }
}

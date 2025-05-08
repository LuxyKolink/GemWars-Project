using UnityEngine;

public class KaidaEnemy : MonoBehaviour
{
    public float speed = 3f;
    public float shootingRange = 8f;
    public float fireCooldown = 2f;
    private float lastShootTime = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public Sprite spriteFrontal;
    public Sprite spriteTrasero;
    public Sprite spritePerfil;

    private GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Eldar");

        if (rb != null)
            rb.gravityScale = 0;
    }

    void Update()
    {
        if (player == null)
            return;

        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        // Movimiento
        rb.linearVelocity = direction * speed;

        // Rotación del FirePoint
        if (firePoint != null)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0, 0, angle);
        }

        // Cambiar sprite según dirección
        UpdateSprite(direction);

        // Disparo si está dentro del rango
        if (Vector2.Distance(transform.position, player.transform.position) <= shootingRange &&
            Time.time >= lastShootTime + fireCooldown)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void UpdateSprite(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Movimiento horizontal
            spriteRenderer.sprite = spritePerfil;
            spriteRenderer.flipX = direction.x < 0;
        }
        else if (direction.y > 0)
        {
            spriteRenderer.sprite = spriteTrasero;
        }
        else if (direction.y < 0)
        {
            spriteRenderer.sprite = spriteFrontal;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

            if (rbBullet != null)
            {
                rbBullet.linearVelocity = firePoint.right * 5f;
            }
        }
    }
}

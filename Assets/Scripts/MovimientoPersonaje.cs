using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;

    // Sprites del personaje
    public Sprite spriteFrontal;
    public Sprite spriteTrasero;
    public Sprite spritePerfil;

    // 🔹 Referencia al FirePoint
    public Transform firePoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (rb == null)
        {
            Debug.LogError("No se encontró un Rigidbody2D en " + gameObject.name);
        }

        if (spriteRenderer == null)
        {
            Debug.LogError("No se encontró un SpriteRenderer en " + gameObject.name);
        }

        rb.gravityScale = 0; // Desactiva la gravedad
    }

    void Update()
    {
        // Capturar la entrada del teclado
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalizar para evitar que diagonal sea más rápido
        movement.Normalize();

        // Cambiar sprite según la dirección
        UpdateSprite();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    void UpdateSprite()
    {
        if (movement != Vector2.zero) // Solo actualizar si hay movimiento
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0, 0, angle);
        }

        if (movement.y > 0) // Movimiento hacia arriba
        {
            spriteRenderer.sprite = spriteTrasero;
        }
        else if (movement.y < 0) // Movimiento hacia abajo
        {
            spriteRenderer.sprite = spriteFrontal;
        }
        else if (movement.x != 0) // Movimiento horizontal
        {
            spriteRenderer.sprite = spritePerfil;
            spriteRenderer.flipX = movement.x < 0;
        }
    }

}

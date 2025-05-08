using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;
    private GameObject player;

    void Start()
    {
        // Buscar al jugador y evitar colisión
        player = GameObject.FindGameObjectWithTag("Eldar");
        if (player != null)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        }

        // Destruir la bala tras X segundos
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si la bala choca con un objeto del entorno (por ejemplo, tagged "Environment")
        if (collision.gameObject.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }
    }
}

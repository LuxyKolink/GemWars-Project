using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;
    public int damage = 1;
    private GameObject player;

    void Start()
    {
        // Buscar al jugador y evitar colisi�n
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
            Debug.Log("La bala de Eldar aachoc� con el entorno.");
            Destroy(gameObject);
            return;
            Destroy(gameObject);
        }

        if (collision.CompareTag("Kaida"))
        {
            // Aqu� podr�as reducir la vida del jugador
            Debug.Log("Kaida recibi� da�o de Eldar");
            Destroy(gameObject);
            return;
            Destroy(gameObject);
        }


    }

    
}

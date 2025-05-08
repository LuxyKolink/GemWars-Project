using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float lifetime = 2f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Eldar"))
        {
            // Aqu� podr�as reducir la vida del jugador
            Debug.Log("Eldar recibi� da�o de Kaida");
        }

        if (!collision.CompareTag("Kaida")) // No destruir al tocar a Kaida
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Environment"))
        {
            Debug.Log("La bala de Kaida choc� con el entorno.");
            Destroy(gameObject);
            return;
            Destroy(gameObject);
        }
    }
}

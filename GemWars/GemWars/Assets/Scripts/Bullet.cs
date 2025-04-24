using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 3f; // Tiempo de vida de la bala

    void Start()
    {
        // Destruye la bala después de 'lifetime' segundos
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destruir la bala si colisiona con cualquier objeto que tenga un Collider2D
        Destroy(gameObject);
    }
}

using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float radioExplosion = 5f; // Radio de la explosión
    public string tagEnemigo = "Enemy"; // El tag para identificar enemigos
    public GameObject explosionPrefab; // Prefab de la explosión

    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador entra en el collider, explota la bomba
        if (other.CompareTag("Player"))
        {
            Explosion();
        }
    }

    private void Explosion()
    {
        // Crear una explosión
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // Encontrar todos los colliders en el radio de la explosión
        Collider[] objetosCercanos = Physics.OverlapSphere(transform.position, radioExplosion);

        foreach (Collider col in objetosCercanos)
        {
            // Verificar si el objeto tiene el tag de enemigo
            if (col.CompareTag(tagEnemigo))
            {
                PuntosManagement.Instance.AddPuntos(1);
                Destroy(col.gameObject); // Eliminar el enemigo
            }
        }

        // Destruir la bomba después de la explosión
        Destroy(explosion, 3f);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        // Dibujar el área de explosión en la vista de escena para referencia
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioExplosion);
    }
}

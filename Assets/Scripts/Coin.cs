using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador entra en el collider, explota la bomba
        if (other.CompareTag("Player"))
        {
            PuntosManagement.Instance.AddPuntos(10);
            Destroy(gameObject);
        }
    }
}

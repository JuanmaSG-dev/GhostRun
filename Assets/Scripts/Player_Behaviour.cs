using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player_Behaviour : MonoBehaviour
{
    public GameObject[] plataformas; // Array de plataformas
    public float moveSpeed = 5f;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed; // Configura la velocidad desde el script
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // Si hay entrada del jugador, mueve el agente
        if (moveDirection != Vector3.zero)
        {
            agent.SetDestination(transform.position + moveDirection);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            PuntosManagement.Instance.RestarPuntos(5);
            GameObject plataformaElegida = plataformas[Random.Range(0, plataformas.Length)];
            transform.position = new Vector3(plataformaElegida.transform.position.x, 8, plataformaElegida.transform.position.z);
        }
    }


    /*IEnumerator Respawn()
    {
        transform.position = new Vector3(0, 9, -8);
    }*/
}

using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    public GameObject enemigoPrefab; // Prefab del enemigo a generar
    public float tiempoEntreGeneraciones = 4f; // Tiempo en segundos entre generaciones
    public float radioGeneracion = 5f; // Radio del área de generación

    private float contadorTiempo; // Control interno del tiempo

    void Update()
    {
        // Incrementamos el contador de tiempo
        contadorTiempo += Time.deltaTime;

        // Si el tiempo supera el intervalo de generación, generamos un enemigo
        if (contadorTiempo >= tiempoEntreGeneraciones)
        {
            GenerarEnemigo();
            contadorTiempo = 0f; // Reiniciamos el contador
        }
    }

    void GenerarEnemigo()
    {
        if (enemigoPrefab == null)
        {
            return;
        }

        // Generar una posición aleatoria en un círculo alrededor del generador
        Vector2 posicionAleatoria2D = Random.insideUnitCircle * radioGeneracion;
        Vector3 posicionGeneracion = new Vector3(
            transform.position.x + posicionAleatoria2D.x,
            transform.position.y,
            transform.position.z + posicionAleatoria2D.y
        );

        // Instanciamos el enemigo en la posición generada
        Instantiate(enemigoPrefab, posicionGeneracion, Quaternion.identity);
    }
}

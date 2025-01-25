using UnityEngine;

public class PlataformaManager : MonoBehaviour
{
    public GameObject[] plataformas; // Array de plataformas
    public GameObject generadorPrefab; // Prefab del generador
    public GameObject bombaPrefab; // Prefab de la bomba
    public GameObject coinPrefab; // Prefab de la moneda
    public float intervaloGeneracion; // Tiempo entre generación de objetos
    public float tiempoVidaGenerador; // Tiempo antes de eliminar el generador
    public float tiempoVidaBomba; // Tiempo antes de eliminar la bomba
    public float tiempoVidaMoneda; // Tiempo antes de eliminar la moneda

    private void Start()
    {
        // Iniciar la generación periódica
        int dificultad = Dificultad.Instance.GetDificultad();
        switch (dificultad) {
            case 0:
                intervaloGeneracion = 6f;
                tiempoVidaGenerador = 3f;
                tiempoVidaBomba = 20f;
                tiempoVidaMoneda = 30f;
                break;
            case 1:
                intervaloGeneracion = 4f;
                tiempoVidaGenerador = 7f;
                tiempoVidaBomba = 25f;
                tiempoVidaMoneda = 35f;
                break;
            case 2:
                intervaloGeneracion = 1f;
                tiempoVidaGenerador = 20f;
                tiempoVidaBomba = 10f;
                tiempoVidaMoneda = 20f;
                break;
        }
        InvokeRepeating(nameof(GenerarObjetoEnPlataforma), intervaloGeneracion, intervaloGeneracion);
    }

    private void GenerarObjetoEnPlataforma()
    {
        GameObject plataformaElegida = plataformas[Random.Range(0, plataformas.Length)];

        // Elegir qué objeto generar (0 = Generador, 1 = Bomba, 2 = Moneda)
        int eleccion = Random.Range(0, 3);
        GameObject objetoGenerado;

        switch (eleccion)
        {
            case 0: // Generador
                objetoGenerado = Instantiate(generadorPrefab, plataformaElegida.transform.position, Quaternion.identity);
                Destroy(objetoGenerado, tiempoVidaGenerador); // Eliminar después del tiempo definido para generador
                break;

            case 1: // Bomba
                objetoGenerado = Instantiate(bombaPrefab, plataformaElegida.transform.position, Quaternion.identity);
                Destroy(objetoGenerado, tiempoVidaBomba); // Eliminar después del tiempo definido para bomba
                break;

            case 2: // Moneda
                objetoGenerado = Instantiate(coinPrefab, plataformaElegida.transform.position, Quaternion.identity);
                Destroy(objetoGenerado, tiempoVidaMoneda); // Eliminar después del tiempo definido para moneda
                break;
        }
    }

}

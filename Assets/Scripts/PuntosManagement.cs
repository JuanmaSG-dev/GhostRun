using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PuntosManagement : MonoBehaviour
{
    public static PuntosManagement Instance;
    public int puntos;
    public TMPro.TextMeshProUGUI puntosText;
    public GameObject DefeatText;
    public GameObject VictoryText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    void Start()
    {
        puntosText.text = "Puntos: " + puntos;
    }

    // Update is called once per frame
    void Update()
    {
        puntosText.text = "Puntos: " + puntos;
        if (puntos < 0) {
            DefeatText.gameObject.SetActive(true);
            StartCoroutine(Defeat());
        } else if (puntos >= 100) {
            VictoryText.gameObject.SetActive(true);
            StartCoroutine(Victory());
        }
    }

    IEnumerator Defeat()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator Victory()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }

    public void AddPuntos(int puntos)
    {
        this.puntos += puntos;
        puntosText.text = "Puntos: " + puntos;
    }

    public void RestarPuntos(int puntos)
    {
        this.puntos -= puntos;
        puntosText.text = "Puntos: " + puntos;
    }
}

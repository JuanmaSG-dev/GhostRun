using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{
    public void FacilButton()
    {
        Dificultad.Instance.Facil();
        SceneManager.LoadScene("Chase");
    }

    public void MedioButton()
    {
        Dificultad.Instance.Medio();
        SceneManager.LoadScene("Chase");
    }

    public void DificilButton()
    {
        Dificultad.Instance.Dificil();
        SceneManager.LoadScene("Chase");
    }


    public void SalirButton()
    {
        Application.Quit();
    }

    public void VolverButton()
    {
        SceneManager.LoadScene("Menu");
    }
}

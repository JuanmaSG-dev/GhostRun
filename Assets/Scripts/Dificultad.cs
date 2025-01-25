using UnityEngine;

public class Dificultad : MonoBehaviour
{

    public static Dificultad Instance;
    public int dificultad; // 0 facil 1 medio 2 dificil

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    void Start()
    {
        dificultad = 0;
    }

    public void Facil() {
        dificultad = 0;
    }

    public void Medio() {
        dificultad = 1;
    }

    public void Dificil() {
        dificultad = 2;
    }

    public int GetDificultad() {
        return dificultad;
    }
}

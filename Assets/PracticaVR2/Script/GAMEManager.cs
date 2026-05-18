using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TextMeshProUGUI Puntos;
    [SerializeField] private TextMeshProUGUI Uipuntos;
    private int puntosconseguidos = 0;
    [SerializeField] private float fin = 20;
    Slider numerosfinal;

    void Start()
    {
        Uipuntos.text = fin.ToString();
    }

    private void Update()
    {
        numerosfinal.value = fin;
    }

    void Awake()
    {
        Instance = this;
    }

    public void Contador()
    {
        puntosconseguidos++;
        ActualizarTexto();

        if (puntosconseguidos >= fin)
        {
            Puntos.text = "¡Has ganadoooo!";
            FindAnyObjectByType<ProySpawner>().StopSpawning();
        }
    }

    public void Descontador()
    {
        puntosconseguidos--;
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        if (Puntos != null)
            Puntos.text = puntosconseguidos + " / " + fin;
    }

    public bool MetaAlcanzada() => puntosconseguidos >= fin;
}

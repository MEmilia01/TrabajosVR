using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TextMeshProUGUI Puntos;
    [SerializeField] private GameObject mandoIzq;
    [SerializeField] private TextMeshProUGUI Uipuntos;
    [SerializeField] private Slider numerosfinal;
    [SerializeField] private bool dosmandos;
    [SerializeField] private int fin = 20;

    private int puntosconseguidos = 0;
    private Scene escenaActual;

    void Awake()
    {
        Instance = this;
        escenaActual = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (numerosfinal != null) numerosfinal.value = puntosconseguidos;
        if (Uipuntos != null) Uipuntos.text = puntosconseguidos + " / " + fin;

        if (mandoIzq != null) mandoIzq.SetActive(dosmandos);
    }

    public void SetObjetivo(int nuevoObjetivo)
    {
        fin = nuevoObjetivo;
    }

    public void Contador()
    {
        puntosconseguidos++;
        ActualizarTexto();

        if (puntosconseguidos >= fin)
        {
            if (Puntos != null) Puntos.text = "¡Has ganadoooo!";

            var spawner = FindAnyObjectByType<ProySpawner>();
            if (spawner != null) spawner.StopSpawning();
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

    public void Unmando() { dosmandos = false; }
    public void Dosmando() { dosmandos = true; }

    public void IrFacil() { SceneManager.LoadScene("vrsFacil"); }
    public void IrDificil() { SceneManager.LoadScene("vrsDificil"); }

    public bool MetaAlcanzada() => puntosconseguidos >= fin;
}
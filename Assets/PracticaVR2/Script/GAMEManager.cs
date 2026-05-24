using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Juego")]
    [SerializeField] private TextMeshProUGUI puntosText;
    [SerializeField] private TextMeshProUGUI mensajeFinalText;
    [SerializeField] private GameObject mandoIzquierdo;

    [Header("Configuración")]
    [SerializeField] private int objetivoPuntos = 20;
    [SerializeField] private bool dosMandos = true;

    private int puntosActuales = 0;
    private ProySpawner spawner;

    public int ObjetivoPuntos => objetivoPuntos;
    public int PuntosActuales => puntosActuales;
    public bool DosMandos => dosMandos;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        BuscarSpawner();
        ActualizarUI();
    }

    private void Update()
    {
        if (mandoIzquierdo != null)
            mandoIzquierdo.SetActive(!dosMandos);
    }

    public void SetObjetivo(int nuevoObjetivo)
    {
        objetivoPuntos = Mathf.Max(1, nuevoObjetivo);
        ActualizarUI();
    }

    public void Unmando()
    {
        dosMandos = false;
    }

    public void Dosmando()
    {
        dosMandos = true;
    }

    public void Contador()
    {
        puntosActuales++;
        ActualizarUI();

        if (puntosActuales >= objetivoPuntos)
        {
            if (mensajeFinalText != null)
                mensajeFinalText.text = "¡Has ganado!";

            if (spawner == null)
                BuscarSpawner();

            if (spawner != null)
                spawner.StopSpawning();
        }
    }

    public void Descontador()
    {
        puntosActuales = Mathf.Max(0, puntosActuales - 1);
        ActualizarUI();
    }

    public bool MetaAlcanzada()
    {
        return puntosActuales >= objetivoPuntos;
    }

    public void ReiniciarPartida()
    {
        puntosActuales = 0;
        if (mensajeFinalText != null)
            mensajeFinalText.text = "";

        ActualizarUI();
        BuscarSpawner();

        if (spawner != null)
            spawner.StartSpawning();
    }

    private void ActualizarUI()
    {
        if (puntosText != null)
            puntosText.text = puntosActuales + " / " + objetivoPuntos;
    }

    private void BuscarSpawner()
    {
        spawner = FindAnyObjectByType<ProySpawner>();
    }
}
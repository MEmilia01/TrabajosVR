using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Juego")]
    [SerializeField] private TextMeshProUGUI puntosText;
    [SerializeField] private TextMeshProUGUI mensajeFinalText;
    [SerializeField] private GameObject mandoIzquierdo;

    [Header("Configuración")]
    [SerializeField] private int objetivoPuntos = 20;
    [SerializeField] public bool dosMandos = true;

    private int puntosActuales = 0;
    private ProySpawner spawner;
    private MenuManager Ui;

    public int ObjetivoPuntos => objetivoPuntos;
    public int PuntosActuales => puntosActuales;

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
        BuscarSpawneryUi();
        ActualizarUI();
    }

    private void Update()
    {
        Ui.AplicarConfiguracion();
    }

    public void SetObjetivo(int nuevoObjetivo)
    {
        objetivoPuntos = Mathf.Max(1, nuevoObjetivo);
        ActualizarUI();
    }

    public void Unmando()
    {

        mandoIzquierdo.SetActive(false);
    }

    public void Dosmando()
    {
        mandoIzquierdo.SetActive(true);
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
                BuscarSpawneryUi();

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
        BuscarSpawneryUi();

        if (spawner != null)
            spawner.StartSpawning();
    }

    private void ActualizarUI()
    {
        if (puntosText != null)
            puntosText.text = puntosActuales + " / " + objetivoPuntos;
    }

    private void BuscarSpawneryUi()
    {
        spawner = FindAnyObjectByType<ProySpawner>();
        Ui = FindAnyObjectByType<MenuManager>();
        if (Ui == null) { return; }
    }
}
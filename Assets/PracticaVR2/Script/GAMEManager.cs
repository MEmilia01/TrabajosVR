using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TextMeshProUGUI Puntos;
    [SerializeField] public GameObject mandoIzq;
    private int puntosconseguidos = 0;
    [SerializeField] private float fin = 20;

    [SerializeField] public TextMeshProUGUI Uipuntos;
    [SerializeField] public Slider numerosfinal;
    [SerializeField] public bool dosmandos;
    Scene escenaActual;


    void Start()
    {    }

    private void Update()
    {
        numerosfinal.value = fin;
        Uipuntos.text = fin.ToString();
        if(dosmandos == false ) { mandoIzq.SetActive(false); }
        else { mandoIzq.SetActive(true); }
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
        if (escenaActual.name != "vrsMenu") { }
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

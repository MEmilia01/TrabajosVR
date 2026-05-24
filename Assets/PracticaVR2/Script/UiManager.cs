using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [Header("UI")]
    [SerializeField] private TMP_Dropdown selectorObjetivo;
    [SerializeField] private Toggle unMando;
    [SerializeField] private Toggle dosMandos;

    private Scene escenaActual;

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
        if (escenaActual.name == "vrsMenu")
        {
            Debug.Log("entra?");
            if (selectorObjetivo != null)
                selectorObjetivo.value = 1;

            if (dosMandos != null)
                dosMandos.isOn = true;
            if (unMando != null)
                unMando.isOn = false;
        }
        else { return; }

        AplicarConfiguracion();
    }

    private void Update()
    {
    }

    public void ElegirUnMando(bool valor)
    {
        if (!valor) return;

        if (dosMandos != null)
            dosMandos.SetIsOnWithoutNotify(false);

        if (GameManager.Instance != null)
            GameManager.Instance.Unmando();
    }

    public void ElegirDosMandos(bool valor)
    {
        if (!valor) return;

        if (unMando != null)
            unMando.SetIsOnWithoutNotify(false);

        if (GameManager.Instance != null)
            GameManager.Instance.Dosmando();
    }

    public void AplicarConfiguracion()
    {
        if (GameManager.Instance == null) return;

        GameManager.Instance.SetObjetivo(ObtenerObjetivoDesdeDropdown());

        ///
        if (dosMandos != null && dosMandos.isOn)
        {
            unMando.isOn = false;
            //Debug.Log("entra");
            GameManager.Instance.Dosmando();
        }
        else if (unMando != null && unMando.isOn)
        { 
            dosMandos.isOn = false;
            //Debug.Log("entra2");
            GameManager.Instance.Unmando();
        }
    }

    public void IrAFacil()
    {
        AplicarConfiguracion();
        SceneManager.LoadScene("vrsFacil");
    }

    public void IrADificil()
    {
        AplicarConfiguracion();
        SceneManager.LoadScene("vrsDificil");
    }

    private int ObtenerObjetivoDesdeDropdown()
    {
        if (selectorObjetivo == null)
            return 20;

        switch (selectorObjetivo.value)
        {
            case 0: return 10;
            case 1: return 20;
            case 2: return 30;
            default: return 20;
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Dropdown selectorObjetivo;   // 1 cubos, 2 cubos, etc.
    [SerializeField] private Toggle unMandoToggle;            // true = un mando
    [SerializeField] private Toggle dosMandosToggle;          // true = dos mandos

    [Header("Opciones")]
    [SerializeField] private int objetivoInicial = 20;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.Dosmando();
        }

        if (selectorObjetivo != null)
        {
            selectorObjetivo.value = 0;
        }

        if (unMandoToggle != null && dosMandosToggle != null)
        {
            unMandoToggle.isOn = false;
            dosMandosToggle.isOn = true;
        }

        AplicarConfiguracion();
    }

    public void AplicarConfiguracion()
    {
        if (GameManager.Instance == null) return;

        int objetivo = objetivoInicial;

        if (selectorObjetivo != null)
        {
            switch (selectorObjetivo.value)
            {
                case 0: objetivo = 10; break;
                case 1: objetivo = 20; break;
                case 2: objetivo = 30; break;
                default: objetivo = objetivoInicial; break;
            }
        }

        GameManager.Instance.SetObjetivo(objetivo);

        bool dosMandos = true;
        if (unMandoToggle != null && dosMandosToggle != null)
        {
            dosMandos = dosMandosToggle.isOn;
        }

        if (dosMandos)
            GameManager.Instance.Dosmando();
        else
            GameManager.Instance.Unmando();
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

    public void SeleccionarUnMando()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.Unmando();
    }

    public void SeleccionarDosMandos()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.Dosmando();
    }
}
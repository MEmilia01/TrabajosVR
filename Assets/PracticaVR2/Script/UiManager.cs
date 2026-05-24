using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Dropdown selectorObjetivo;
    [SerializeField] private Toggle unMandoToggle;
    [SerializeField] private Toggle dosMandosToggle;

    private void Start()
    {
        if (selectorObjetivo != null)
            selectorObjetivo.value = 1;

        if (dosMandosToggle != null)
            dosMandosToggle.isOn = true;

        if (unMandoToggle != null)
            unMandoToggle.isOn = false;

        AplicarConfiguracion();
    }

    public void ElegirUnMando(bool valor)
    {
        if (!valor) return;

        if (dosMandosToggle != null)
            dosMandosToggle.SetIsOnWithoutNotify(false);

        if (GameManager.Instance != null)
            GameManager.Instance.Unmando();
    }

    public void ElegirDosMandos(bool valor)
    {
        if (!valor) return;

        if (unMandoToggle != null)
            unMandoToggle.SetIsOnWithoutNotify(false);

        if (GameManager.Instance != null)
            GameManager.Instance.Dosmando();
    }

    public void AplicarConfiguracion()
    {
        if (GameManager.Instance == null) return;

        GameManager.Instance.SetObjetivo(ObtenerObjetivoDesdeDropdown());

        if (dosMandosToggle != null && dosMandosToggle.isOn)
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
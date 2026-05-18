using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI Uipuntos;
    [SerializeField] public Slider numerosfinal;
    [SerializeField] public bool dosmandos = true;

    void Unmando() { dosmandos = false; }
    void IrFacil() { SceneManager.LoadScene("vrsFacil"); }
    void IrDificil() { SceneManager.LoadScene("vrsDificil"); }
}

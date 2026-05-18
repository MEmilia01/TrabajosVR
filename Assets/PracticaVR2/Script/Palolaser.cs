using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;

public class PaloLaser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Entra");
            GameManager.Instance.Contador();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Bomba"))
        {
            Debug.Log("desentra");
            GameManager.Instance.Descontador();
            Destroy(other.gameObject);
        }
    }
}

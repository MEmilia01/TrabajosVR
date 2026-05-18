using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProySpawner : MonoBehaviour
{
    [SerializeField] public GameObject Cubo;
    [SerializeField] public GameObject Bomba;
    [SerializeField] private Transform player;
    [SerializeField] public float Distancia = 10f;
    [SerializeField] public float bombaPro = 0.3f;
    [SerializeField] private float AngCubo = 90f;
    [SerializeField] float tiempoSpawn = 4f;
    Scene escenaActual;
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private void Update()
    {
        escenaActual = SceneManager.GetActiveScene();
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoSpawn);

            if (escenaActual.name == "vrsMenu") {  }
            else if (escenaActual.name == "vrsDificil")
            {
                if (Random.value <= bombaPro) { SpawnBomba(); }
                else { SpawnCubo(); }
            }
            else { SpawnCubo(); } 
        }
    }

    public void StopSpawning()
    {
        StopCoroutine(SpawnLoop());
    }

    void SpawnCubo()
    {
        Instantiate(Cubo, GetSpawnPosition(), Quaternion.identity);
    }

    void SpawnBomba()
    {
        Instantiate(Bomba, GetSpawnPosition(), Quaternion.identity);
    }

    Vector3 GetSpawnPosition()
    {
        Vector3 playerForward = player.forward;
        playerForward.y = 0f;
        playerForward.Normalize();

        float randAngle = Random.Range(-AngCubo / 2f, AngCubo / 2f);
        Quaternion rot = Quaternion.AngleAxis(randAngle, Vector3.up);
        Vector3 direction = rot * playerForward;

        Vector3 pos = player.position + direction * Distancia;
        pos.y = 1.5f;

        return pos;
    }
}

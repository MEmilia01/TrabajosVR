using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Cubo;
    [SerializeField] private GameObject Bomba;
    [SerializeField] private Transform player;
    [SerializeField] private float Distancia = 10f;
    [SerializeField] private float bombaPro = 0.3f;
    [SerializeField] private float AngCubo = 90f;
    [SerializeField] private float tiempoSpawn = 4f;

    private Scene escenaActual;
    private Coroutine spawnCoroutine;
    private bool spawning;

    private void Start()
    {
        StartSpawning();
    }

    private void Update()
    {
        escenaActual = SceneManager.GetActiveScene();
    }

    public void StartSpawning()
    {
        if (spawning) return;

        spawning = true;
        spawnCoroutine = StartCoroutine(SpawnLoop());
    }

    public void StopSpawning()
    {
        spawning = false;

        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    private IEnumerator SpawnLoop()
    {
        while (spawning)
        {
            yield return new WaitForSeconds(tiempoSpawn);

            if (escenaActual.name == "vrsMenu")
            {
                continue;
            }
            else if (escenaActual.name == "vrsDificil")
            {
                if (Random.value <= bombaPro)
                    SpawnBomba();
                else
                    SpawnCubo();
            }
            else
            {
                SpawnCubo();
            }
        }
    }

    private void SpawnCubo()
    {
        Instantiate(Cubo, GetSpawnPosition(), Quaternion.identity);
    }

    private void SpawnBomba()
    {
        Instantiate(Bomba, GetSpawnPosition(), Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj == null) return Vector3.zero;
            player = playerObj.transform;
        }

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
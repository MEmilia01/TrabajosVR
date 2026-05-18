using UnityEngine;

public class MovProyectiles : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector3 direccion;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return;

        Vector3 objetivo = player.transform.position;
        objetivo.y = 1.55f;

        Vector3 origen = transform.position;
        origen.y = 1.55f;

        direccion = (objetivo - origen).normalized;
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += direccion * speed * Time.deltaTime;
    }
}

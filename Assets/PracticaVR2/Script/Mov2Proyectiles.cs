using UnityEngine;

public class Mov2Proyectiles : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        if (player == null) return;

        Vector3 objetivo = player.position;
        objetivo.y = Camera.main.transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, objetivo, speed * Time.deltaTime);

        transform.LookAt(player);
    }
}

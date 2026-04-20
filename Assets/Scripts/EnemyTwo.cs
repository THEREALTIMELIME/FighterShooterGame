using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public float speed = 3f;
    public float waveFrequency = 2f;
    public float waveMagnitude = 2f;

    public GameObject explosionPrefab;
    public GameObject shieldPrefab;

    float startX;
    private GameManager gameManager;

    void Start()
    {
        startX = transform.position.x;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        float x = startX + Mathf.Sin(Time.time * waveFrequency) * waveMagnitude;
        float y = transform.position.y - speed * Time.deltaTime;

        transform.position = new Vector3(x, y, 0);

        if (transform.position.y < -gameManager.verticalScreenSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            whatDidIHit.GetComponent<PlayerController>().LoseALife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (whatDidIHit.tag == "Weapons")
        {
            Destroy(whatDidIHit.gameObject);

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameManager.AddScore(10);

            if (Random.value < 0.3f)
            {
                Instantiate(shieldPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
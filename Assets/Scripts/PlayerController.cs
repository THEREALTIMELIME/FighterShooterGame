using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int lives;
    private float speed;

    private GameManager gameManager;

    private float horizontalInput;
    private float verticalInput;

    public GameObject bulletPrefab;
    public GameObject explosionPrefab;

    public bool hasShield = false;
    public GameObject shieldVisual;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lives = 3;
        speed = 5.0f;

        gameManager.ChangeLivesText(lives);

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(false);
        }
    }

    void Update()
    {
        Movement();
        Shooting();
    }

    public void LoseALife()
    {
        // 🛡️ BLOCK DAMAGE IF SHIELD ACTIVE
        if (hasShield)
        {
            hasShield = false;

            if (shieldVisual != null)
            {
                shieldVisual.SetActive(false);
            }

            return;
        }

        lives--;
        gameManager.ChangeLivesText(lives);

        if (lives == 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void ActivateShield()
    {
        hasShield = true;

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(true);
        }

        // Optional auto-expire
        Invoke("DeactivateShield", 5f);
    }

    void DeactivateShield()
    {
        hasShield = false;

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(false);
        }
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab,
                transform.position + new Vector3(0, 0.5f, 0),
                Quaternion.identity);
        }
    }

    void Movement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);

        if (movement != Vector3.zero)
        {
            transform.Translate(movement * Time.deltaTime * speed);
        }

        float horizontalScreenSize = gameManager.horizontalScreenSize;
        float verticalScreenSize = gameManager.verticalScreenSize;

        if (transform.position.x <= -horizontalScreenSize || transform.position.x > horizontalScreenSize)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        if (transform.position.y <= -verticalScreenSize || transform.position.y > verticalScreenSize)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }
}
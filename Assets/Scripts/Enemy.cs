using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject shieldPrefab; // 🛡️ NEW

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            whatDidIHit.GetComponent<PlayerController>().LoseALife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (whatDidIHit.tag == "Weapons")
        {
            Destroy(whatDidIHit.gameObject);

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameManager.AddScore(5);

            if (Random.value < 0.3f)
            {
                Instantiate(shieldPrefab, transform.position, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }
}
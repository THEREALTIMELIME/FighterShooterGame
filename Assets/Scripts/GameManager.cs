using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject cloudPrefab;

    public TextMeshProUGUI livesText;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;

    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;

        Instantiate(playerPrefab, transform.position, Quaternion.identity);

        CreateSky();

        InvokeRepeating("CreateEnemyOne", 1, 2f);
        InvokeRepeating("CreateEnemyTwo", 2, 3.5f);
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab,
            new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f,
            verticalScreenSize, 0),
            Quaternion.Euler(180, 0, 0));
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab,
            new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f,
            verticalScreenSize, 0),
            Quaternion.Euler(180, 0, 0));
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab,
                new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize),
                Random.Range(-verticalScreenSize, verticalScreenSize), 0),
                Quaternion.identity);
        }
    }

    public void AddScore(int earnedScore)
    {
        score += earnedScore;
    }

    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
}
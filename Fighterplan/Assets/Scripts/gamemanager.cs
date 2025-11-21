using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject cloudPrefab;
    public GameObject coinPrefab;
    public GameObject shieldPowerUpPrefab;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public float horizontalScreenSize;
    public float verticalScreenSize;
    
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        scoreText.text = "Score: 0";
        Instantiate(playerPrefab, new Vector3(0f, -3f, 0f), Quaternion.identity);
        CreateSky();
        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyTwo", 2, 3);
        InvokeRepeating("CreateCoin", 1, 10);
        InvokeRepeating("CreateShieldPowerUp", 5, 15);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }
    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(-9.5f, Random.Range(-1f, 6f),0), Quaternion.identity);
    }
    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }
    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }

    }
    void CreateShieldPowerUp()
    {
        Instantiate(
            shieldPowerUpPrefab,
            new Vector3(Random.Range(-9f, 9f), 6.5f, 0),
            Quaternion.identity
        );
    }
    public void addScore(int earnedScore)
    {
        score = score + earnedScore;
        scoreText.text = "Score: " + score;
    }

    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
}


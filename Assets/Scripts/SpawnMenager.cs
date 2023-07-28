using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnMenager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    private int waveNumber = 1;
    private PlayerController playerControllerScript;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lastScore;
    public TextMeshProUGUI lastScore2;
    public float score =0;
    public static SpawnMenager sm;
    void Start()
    {
        sm = this;
        SpawnWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
            scoreText.text = (int)score + " ";
        }
        if(score > PlayerPrefs.GetInt("_highScore"))
        {
            PlayerPrefs.SetInt("_highScore", (int)score);
        }
        if(playerControllerScript.gameOver == false)
        {
            lastScore.text = (int)score + " ";
        
            lastScore2.text = (int)score + " ";
        }

        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount ==0)
        {
            waveNumber++;
            SpawnWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
    void SpawnWave(int spawnEnemies)
    {
        for(int i = 0 ; i < spawnEnemies ; i++)
        {
           GameObject enemy = Instantiate(enemyPrefab,GenerateSpawnPosition(),enemyPrefab.transform.rotation);
           //enemy.GetComponent<Enemy>()
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange,spawnRange);
        float spawnPosZ = Random.Range(-spawnRange,spawnRange);
        Vector3 randomPos =  new Vector3(spawnPosX,0,spawnPosZ);
        return randomPos;
    }
}

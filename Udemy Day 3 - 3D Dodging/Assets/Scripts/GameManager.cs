using System.Numerics;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject stone;
    public float maxX;
    public Transform stoneSpawnPoint;
    public TextMeshProUGUI scoreText;
    int score = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnStone", 0.5f, 1.5f);

        InvokeRepeating("UpdateScore", 3f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnStone()
    {
        UnityEngine.Vector3 spawnPos = stoneSpawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(stone, spawnPos, UnityEngine.Quaternion.identity);
    }

    void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}

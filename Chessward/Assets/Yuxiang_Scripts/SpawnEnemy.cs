using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    float roomLength = 100;

    public float numOfEnemies;

    public GameObject EnemyPawn;
    public GameObject EnemyKnight;
    public StartScreen startScreenScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfEnemies == 0 && startScreenScript.GameStarted)
        {
            startGame(1);
        }
    }

    public void startGame(int difficulty)
    {
        numOfEnemies = difficulty;
        Instantiate(EnemyPawn, randomPosition(), EnemyPawn.transform.rotation);
        //Instantiate(EnemyKnight, randomPosition(), EnemyKnight.transform.rotation);
    }

    Vector3 randomPosition()
    {
        int x = Random.Range(1, 8);
        int z = Random.Range(1, 8);
        return new Vector3(roomLength / 2 + x * roomLength, 10, roomLength / 2 + z * roomLength);
    }
}

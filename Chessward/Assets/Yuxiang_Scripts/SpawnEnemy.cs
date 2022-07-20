using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    float roomLength = 100;
    public GameObject EnemyPawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame(int numOfEnemy)
    {
        Instantiate(EnemyPawn, randomPosition(), EnemyPawn.transform.rotation);
    }

    Vector3 randomPosition()
    {
        int x = Random.Range(0, 8);
        int z = Random.Range(0, 8);
        return new Vector3(roomLength / 2 + x * roomLength, 10, roomLength / 2 + z * roomLength);
    }
}

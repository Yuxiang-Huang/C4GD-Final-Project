using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    float roomLength = 100;

    public float numOfEnemies;

    public GameObject EnemyPawn;
    public GameObject EnemyKnight;
    public GameObject EnemyBishop;
    public GameObject EnemyRook;
    public GameObject EnemyQueen;
    public GameObject EnemyKing;

    public GameObject Objective1;
    public GameObject Objective2;

    public List<EnemyDummyIntro> enemies; 

    public StartScreen startScreenScript;

    public GameObject EnemyDummy;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfEnemies == 0 && startScreenScript.GameStarted)
        { 
            startScreenScript.displayWinEndScreen();
        }
    }

    public void startGame()
    {
        if (startScreenScript.difficulty == "tutorial")
        {
            numOfEnemies = 6;
            GameObject Pawn = Instantiate(EnemyPawn, new Vector3(50, 0, 150), EnemyPawn.transform.rotation);
            enemies.Add(Pawn.GetComponent<EnemyDummyIntro>());

            GameObject Knight = Instantiate(EnemyKnight, randomPosition(), EnemyKnight.transform.rotation);
            enemies.Add(Knight.GetComponent<EnemyDummyIntro>());

            GameObject Bishop = Instantiate(EnemyBishop, randomPosition(), EnemyBishop.transform.rotation);
            enemies.Add(Bishop.GetComponent<EnemyDummyIntro>());

            GameObject Rook = Instantiate(EnemyRook, randomPosition(), EnemyRook.transform.rotation);
            enemies.Add(Rook.GetComponent<EnemyDummyIntro>());

            GameObject Queen = Instantiate(EnemyQueen, randomPosition(), EnemyQueen.transform.rotation);
            enemies.Add(Queen.GetComponent<EnemyDummyIntro>());

            GameObject King = Instantiate(EnemyKing, randomPosition(), EnemyKing.transform.rotation);
            enemies.Add(King.GetComponent<EnemyDummyIntro>());
        }

        else
        {
            numOfEnemies = 6;
            GameObject Pawn = Instantiate(EnemyPawn, randomPosition(), EnemyPawn.transform.rotation);
            enemies.Add(Pawn.GetComponent<EnemyDummyIntro>());
            
            GameObject Knight = Instantiate(EnemyKnight, randomPosition(), EnemyKnight.transform.rotation);
            enemies.Add(Knight.GetComponent<EnemyDummyIntro>());

            GameObject Bishop = Instantiate(EnemyBishop, randomPosition(), EnemyBishop.transform.rotation);
            enemies.Add(Bishop.GetComponent<EnemyDummyIntro>());

            GameObject Rook = Instantiate(EnemyRook, randomPosition(), EnemyRook.transform.rotation);
            enemies.Add(Rook.GetComponent<EnemyDummyIntro>());

            GameObject Queen = Instantiate(EnemyQueen, randomPosition(), EnemyQueen.transform.rotation);
            enemies.Add(Queen.GetComponent<EnemyDummyIntro>());

            GameObject King = Instantiate(EnemyKing, randomPosition(), EnemyKing.transform.rotation);
            enemies.Add(King.GetComponent<EnemyDummyIntro>());
        }

        if (startScreenScript.difficulty == "easy" || startScreenScript.difficulty == "hard")
        {
            Objective1.SetActive(true);
            Objective2.SetActive(false);
        }
        else if (startScreenScript.difficulty == "medium" || startScreenScript.difficulty == "impossible")
        {
            Objective2.SetActive(true);
            Objective1.SetActive(false);
        }
    }

    Vector3 randomPosition()
    {
        int x = Random.Range(1, 8);
        int z = Random.Range(1, 8);
        return new Vector3(roomLength / 2 + x * roomLength, 30, roomLength / 2 + z * roomLength);
    }
}

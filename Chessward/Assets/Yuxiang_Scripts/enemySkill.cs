using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemySkill : MonoBehaviour
{
    public string pieceName;
    private GameObject player;
    private float coolDown;
    public float roomLength = 100;
    public StartScreen startScreenScript;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        startCoolDown();
        startScreenScript = GameObject.Find("Screen Manager").GetComponent<StartScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startScreenScript.difficulty == "hard" || startScreenScript.difficulty == "impossible")
        {
            
            if (coolDown <= 0)
            {
                agent.enabled = false;

                switch (pieceName)
                {
                    case "Rook":
                        FindSquareForRook();
                        break;
                    case "Knight":
                        FindSquareForKnight();
                        break;
                    case "Bishop":
                        FindSquareForBishop();
                        break;
                    case "Queen":
                        FindSquareForQueen();
                        break;
                    case "Pawn":
                        FindSquareForPawn();
                        break;
                    case "King":
                        if (startScreenScript.difficulty == "hard")
                        {
                            FindSquareForKingFar();
                        }
                        else
                        {
                            FindSquareForKing();
                        }
                        break;
                }
                startCoolDown();

                agent.enabled = true;
            }
            else
            {
                coolDown -= Time.deltaTime;
            }

            if (pieceName == "Pawn" && (int)(transform.position.z / roomLength) == 0)
            {
                pieceName = "Queen";
            }
        }
    }

    void FindSquareForRook()
    {
        //if (findDistance(new Vector3(transform.position.x, transform.position.y, player.transform.position.z), player.transform.position) <
        //    findDistance(new Vector3(player.transform.position.x, transform.position.y, transform.position.z), player.transform.position))
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
        //}
        //else
        //{
        //    transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        //}
        Vector3 enemy = transform.position;
        Vector3 min = enemy;
        float minDist = findDistance(enemy, player.transform.position);
        min = FindSquareHelper(enemy, 1, 0, min, minDist);
        min = FindSquareHelper(enemy, -1, 0, min, minDist);
        min = FindSquareHelper(enemy, 0, 1, min, minDist);
        min = FindSquareHelper(enemy, 0, -1, min, minDist);
        transform.position = min;

        ////slow set
        //int desXPos = (int)(min.x / roomLength);
        //int desYPos = (int)(min.z / roomLength);
        //int xPos = (int)(transform.position.x / roomLength);
        //int yPos = (int)(transform.position.z / roomLength);

        //while (xPos != desXPos || yPos != desYPos)
        //{
        //    if (xPos > desXPos)
        //    {
        //        xPos--;
        //    } else if (xPos < desXPos)
        //    {
        //        xPos++;
        //    }

        //    if (yPos > desYPos)
        //    {
        //        yPos--;
        //    }
        //    else if (yPos < desYPos)
        //    {
        //        yPos++;
        //    }
        //    transform.position = new Vector3(xPos * roomLength + transform.position.x % roomLength, transform.position.y,
        //        yPos * roomLength + transform.position.z % roomLength);
        //}
        
        //Debug.Log(min);
    }

    float findDistance(Vector3 pointA, Vector3 pointB)
    {
        return Mathf.Sqrt(Mathf.Pow((pointA.x - pointB.x), 2) + Mathf.Pow((pointA.z - pointB.z), 2));
    }

    void FindSquareForKnight()
    {
        Vector3 enemy = transform.position;
        Vector3 playerPos = player.transform.position;
        Vector3 min = enemy;
        float minDist = findDistance(playerPos, min);

        for (int row = -1; row <= 1; row += 2)
        {
            for (int col = -1; col <= 1; col += 2)
            {
                Vector3 candidate = new Vector3(enemy.x + row * roomLength * 2, 0, enemy.z + col * roomLength);
                if (inBound(candidate))
                {
                    
                    if (findDistance(playerPos, candidate) < minDist)
                    {
                        min = candidate;
                        minDist = findDistance(playerPos, candidate);
                    }
                    
                }

                Vector3 candidate2 = new Vector3(enemy.x + row * roomLength, 0, enemy.z + col * roomLength * 2);
                if (inBound(candidate2))
                {
                    
                        if (findDistance(playerPos, candidate2) < minDist)
                        {
                            min = candidate2;
                            minDist = findDistance(playerPos, candidate2);
                        }
                    
                }
            }
        }

        transform.position = min;
    }

    void FindSquareForKing()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 min = transform.position;
        float minDist = findDistance(playerPos, min);

        for (int rowInc = -1; rowInc <= 1; rowInc++)
        {
            for (int colInc = -1; colInc <= 1; colInc++)
            {
                if (!(rowInc == 0 && colInc == 0))
                {
                    Vector3 candidate = new Vector3(transform.position.x + rowInc * roomLength, transform.position.y,
                        transform.position.z + colInc * roomLength);
                    if (inBound(candidate))
                    {
                        if (findDistance(playerPos, candidate) < minDist)
                        {
                            min = candidate;
                            minDist = findDistance(playerPos, candidate);
                        }                
                    }
                }
            }
        }
        transform.position = min;
    }

    void FindSquareForKingFar()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 min = transform.position;
        float minDist = findDistance(playerPos, min);

        for (int rowInc = -1; rowInc <= 1; rowInc++)
        {
            for (int colInc = -1; colInc <= 1; colInc++)
            {
                if (!(rowInc == 0 && colInc == 0))
                {
                    Vector3 candidate = new Vector3(transform.position.x + rowInc * roomLength, transform.position.y,
                        transform.position.z + colInc * roomLength);
                    if (inBound(candidate))
                    {
                        if (findDistance(playerPos, candidate) > minDist)
                        {
                            min = candidate;
                            minDist = findDistance(playerPos, candidate);
                        }
                    }
                }
            }
        }
        transform.position = min;
    }

    void FindSquareForPawn()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - roomLength);
    }

    void FindSquareForBishop()
    {
        Vector3 enemy = transform.position;
        Vector3 min = enemy;
        float minDist = findDistance(enemy, player.transform.position);
        min = FindSquareHelper(enemy, 1, 1, min, minDist);
        min = FindSquareHelper(enemy, -1, 1, min, minDist);
        min = FindSquareHelper(enemy, 1, -1, min, minDist);
        min = FindSquareHelper(enemy, -1, -1, min, minDist);
        transform.position = min;
        //Debug.Log(min);
    }

    void FindSquareForQueen()
    {
        Vector3 enemy = transform.position;
        Vector3 min = enemy;
        float minDist = findDistance(enemy, player.transform.position);
        min = FindSquareHelper(enemy, 1, 1, min, minDist);
        min = FindSquareHelper(enemy, -1, 1, min, minDist);
        min = FindSquareHelper(enemy, 1, -1, min, minDist);
        min = FindSquareHelper(enemy, -1, -1, min, minDist);
        min = FindSquareHelper(enemy, 1, 0, min, minDist);
        min = FindSquareHelper(enemy, -1, 0, min, minDist);
        min = FindSquareHelper(enemy, 0, 1, min, minDist);
        min = FindSquareHelper(enemy, 0, -1, min, minDist);
        transform.position = min;
        //Debug.Log(min);
    }

    Vector3 FindSquareHelper(Vector3 enemy, int xChange, int zChange, Vector3 min, float minDist)
    {
        enemy = new Vector3(enemy.x + xChange * roomLength, enemy.y, enemy.z + zChange * roomLength);

        while (inBound(enemy))
        {
            if(findDistance(player.transform.position, enemy) < minDist)
            {
                min = enemy;
                minDist = findDistance(player.transform.position, enemy);
            }
            enemy = new Vector3(enemy.x + xChange * roomLength, enemy.y, enemy.z + zChange * roomLength);
        }
        return min;
    }

    bool inBound(Vector3 candidate)
    {
        return candidate.x >= 0 && candidate.x <= 800 && candidate.z >= 0 && candidate.z <= 800;
    }


    public void startCoolDown()
    {
        switch (pieceName)
        {
            case "Rook":
                coolDown = 5;
                break;
            case "Knight":
                coolDown = 3;
                break;
            case "Bishop":
                coolDown = 3;
                break;
            case "Queen":
                coolDown = 9;
                break;
            case "Pawn":
                coolDown = 1;
                break;
            case "King":
                coolDown = 2;
                break;
        }
    }
}

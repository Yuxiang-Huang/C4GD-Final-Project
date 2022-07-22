using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDummyIntro : MonoBehaviour
{
    public int health;
    private int damage;
    private int sniperdamage;
    private int smgdamage;
    private int revolverDamage;
    private int shotgunDamage;
    private int SwordDamage;
    public GameObject Player;
    public GameObject EnemyWeapon;
    public SpawnEnemy spawnEnemyScript;
    public MiniMap minimapScript;
    public StartScreen startScreenScript;

    public TeleportManager teleportManager;
    public int xPos;
    public int yPos;
    public float roomLength = 100;
    public string pieceName;
    public DoorControlTutorial doorControlTutorialScript;

    [SerializeField] private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        health = 100;

        switch (pieceName)
        {
            case "Rook":
                health = 100;
                break;
            case "Knight":
                health = 100;
                break;
            case "Bishop":
                health = 100;
                break;
            case "Queen":
                health = 100;
                break;
            case "Pawn":
                health = 100;
                break;
            case "King":
                health = 150;
                break;
        }

        startScreenScript = GameObject.Find("Screen Manager").GetComponent<StartScreen>();

        //if (startScreenScript.difficulty == "hard" || startScreenScript.difficulty == "impossible")
        //{
        //    health *= 2;
        //}

        damage = 10;
        smgdamage = 5;
        sniperdamage = 100;
        revolverDamage = 15;
        shotgunDamage = 10;
        SwordDamage = 50;
        EnemyWeapon.gameObject.SetActive(true);
        spawnEnemyScript = GameObject.Find("SpawnManager").GetComponent<SpawnEnemy>();
        teleportManager = GameObject.Find("Teleport Manager").GetComponent<TeleportManager>();
        
        minimapScript = GameObject.Find("MiniMap").GetComponent<MiniMap>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPostition = new Vector3(Player.transform.position.x,
                                        this.transform.position.y,
                                        Player.transform.position.z);
        this.transform.LookAt(targetPostition);

        int xPosNow = (int)(transform.position.x / roomLength);
        int yPosNow = (int)(transform.position.z / roomLength);

        if (xPosNow != xPos || yPosNow != yPos)
        {
            teleportManager.enemySquare[xPos][yPos] = false;
            xPos = xPosNow;
            yPos = yPosNow;
            teleportManager.enemySquare[xPos][yPos] = true;
        }
        if (!startScreenScript.isTutorial)
        {
            //if (pieceName == "Pawn")
            //{
            //    agent.SetDestination(Player.transform.position);
            //}
            //else
            //{
                //if (findDistance(Player.transform, transform) > 50)
                //{
                //    agent.SetDestination(Player.transform.position);
                //}
                //else
                //{
            agent.SetDestination(Player.transform.position);
                
            
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            health = health - damage;
        }
        if (other.gameObject.CompareTag("SniperBullet"))
        {
            health = health - sniperdamage;
        }
        if (other.gameObject.CompareTag("smgBullet"))
        {
            health = health - smgdamage;
        }
        if (other.gameObject.CompareTag("RevolverBullet"))
        {
            health = health - revolverDamage;
        }
        if (other.gameObject.CompareTag("shotGunBullet"))
        {
            health = health - shotgunDamage;
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            health = health - SwordDamage;
        }
        else
        {
            Destroy(other.gameObject);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            EnemyWeapon.gameObject.SetActive(false);
            spawnEnemyScript.enemies.Remove(this);
            teleportManager.enemySquare[xPos][yPos] = false;
            switch (pieceName)
            {
                case "Pawn":
                    minimapScript.BlackPawnImage.SetActive(false);
                    break;
                case "Knight":
                    minimapScript.BlackKnightImage.SetActive(false);
                    break;
                case "Bishop":
                    minimapScript.BlackBishopImage.SetActive(false);
                    break;
                case "Rook":
                    minimapScript.BlackRookImage.SetActive(false);
                    break;
                case "Queen":
                    minimapScript.BlackQueenImage.SetActive(false);
                    break;
                case "King":
                    if (startScreenScript.difficulty == "easy" || startScreenScript.difficulty == "hard")
                    {
                        spawnEnemyScript.numOfEnemies = 0;
                    }
                    minimapScript.BlackKingImage.SetActive(false);
                    break;
            }
        }
    }

    float findDistance(Transform pointA, Transform pointB)
    {
        return Mathf.Sqrt(Mathf.Pow((pointA.transform.position.x - pointB.transform.position.x), 2)
          + Mathf.Pow((pointA.transform.position.z - pointB.transform.position.z), 2));
    }


}

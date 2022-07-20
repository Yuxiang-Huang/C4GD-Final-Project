using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDummyIntro : MonoBehaviour
{
    public int health;
    private int damage;
    public GameObject Player;
    public GameObject EnemyWeapon;
    public SpawnEnemy spawnEnemyScript;

    public TeleportManager teleportManager;
    public int xPos;
    public int yPos;
    public float roomLength = 100;
    public string pieceName;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        health = 100;
        damage = 10;
        EnemyWeapon.gameObject.SetActive(true);
        spawnEnemyScript = GameObject.Find("SpawnManager").GetComponent<SpawnEnemy>();
        teleportManager = GameObject.Find("Teleport Manager").GetComponent<TeleportManager>();
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health = health - damage;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            EnemyWeapon.gameObject.SetActive(false);
            spawnEnemyScript.numOfEnemies--;
            teleportManager.enemySquare[xPos][yPos] = false;
        }
    }

}

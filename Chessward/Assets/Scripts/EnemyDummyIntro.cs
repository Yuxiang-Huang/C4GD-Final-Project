using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDummyIntro : MonoBehaviour
{
    public int health;
    private int damage;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        damage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPostition = new Vector3(Player.transform.position.x,
                                        this.transform.position.y,
                                        Player.transform.position.z);
        this.transform.LookAt(targetPostition);
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
        }
    }

}

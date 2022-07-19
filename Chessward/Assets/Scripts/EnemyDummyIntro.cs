using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDummyIntro : MonoBehaviour
{
    public int health;
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        damage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
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

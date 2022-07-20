using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject Enemy;
    private Vector3 offset = new Vector3(0, 4, 0);
    public GameObject projectilePrefab;
    private float shootTime;
    public int magSize;
    // Start is called before the first frame update
    void Start()
    {
        //Enemy = GameObject.Find("Enemy");
        magSize = 30;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        shootTime = shootTime + Time.deltaTime;
        transform.position = Enemy.transform.position + offset;
        transform.rotation = Enemy.transform.rotation;
        transform.position += transform.right * 2.5f;
        transform.position += transform.forward * 1.5f;
        if (shootTime > 0.6 && magSize > 0)
        {
            Vector3 offset2 = transform.up * 0.5f + transform.forward * 8f;
            shootTime = 0;
            Instantiate(projectilePrefab, transform.position + offset2, transform.rotation);
            magSize = magSize - 1;
            StartCoroutine(MagCheck());
        }
    }
    IEnumerator MagCheck()
    {
        if (magSize <= 0)
        {
            yield return new WaitForSeconds(5);
            magSize = 30;
        }
    }
}

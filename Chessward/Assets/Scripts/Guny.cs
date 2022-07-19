using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guny : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset = new Vector3(0, 15, 0);
    public GameObject projectilePrefab;
    private float shootTime;
    public int magSize;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        magSize = 30;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        shootTime = shootTime + Time.deltaTime;
        transform.position = Player.transform.position + offset;
        transform.rotation = Player.transform.rotation;
        transform.position += transform.right;
        transform.position += transform.forward;
        if (Input.GetKey(KeyCode.Q) && shootTime > 0.2 && magSize > 0)
        {
            Vector3 offset2 = transform.up * 0.5f + transform.forward * 8f;
            shootTime = 0;
            Instantiate(projectilePrefab, transform.position + offset2, transform.rotation);
            magSize = magSize - 1;
            StartCoroutine(MagCheck());
        }
    }
    IEnumerator MagCheck() {
        if (magSize <= 0)
        {
            yield return new WaitForSeconds(3);
            magSize = 30;
        }
    }
}

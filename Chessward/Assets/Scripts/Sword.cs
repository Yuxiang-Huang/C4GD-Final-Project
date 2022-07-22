using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject Player;
    private float swingTime;
    private Vector3 offset = new Vector3(0, 14, 0);
    private AudioSource SwordAudio;
    public AudioClip swingSound;
    private float rotX;
    private float rotY;
    private float rotZ;
    private bool SwordS = false;
    private bool SwordS2 = false;
    // Start is called before the first frame update
    void Start()
    {
        SwordS = false;
        SwordS2 = false;
        SwordAudio = GetComponent<AudioSource>();
        swingTime = 0;
        rotX = 0;
        rotY = 0;
        rotZ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        swingTime = swingTime + Time.deltaTime;
        transform.position = Player.transform.position + offset;
        transform.rotation = Player.transform.rotation;
        transform.position += transform.forward * 2;
        transform.position += transform.up * -1;


        if (Input.GetKey(KeyCode.Mouse0) && swingTime > 0.7f)
        {
            SwordS = true;
            StartCoroutine(Bleep());
        }

        if (SwordS == true)
        {
            transform.Rotate(rotX, rotY, rotZ);
            rotX = rotX + 230f * Time.deltaTime;
            rotY = rotY - 200f * Time.deltaTime;
            rotZ = rotZ + 160f * Time.deltaTime;
            if (rotX >= 55)
            {
                rotX = 55;
            }
            if (rotY <= -40)
            {
                rotY = -40;
            }
            if (rotZ >= 50)
            {
               rotZ = 50;
            }
            swingTime = 0;
        }
        if (SwordS2 == true)
        {
            transform.Rotate(rotX, rotY, rotZ);
            rotX = rotX - 230f * Time.deltaTime;
            rotY = rotY + 200f * Time.deltaTime;
            rotZ = rotZ - 160f * Time.deltaTime;
            if (rotX <= -55)
            {
                rotX = -55;
            }
            if (rotY >= 40)
            {
                rotY = 40;
            }
            if (rotZ <= -50)
            {
                rotZ = -50;
            }
        }
        transform.Rotate(-60, 60, -30);
    }
    IEnumerator Bleep() {
        SwordAudio.PlayOneShot(swingSound, 1.0f);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(BleepBack());
    }
    IEnumerator BleepBack() { 
    SwordS2 = true;
    SwordS = false;
    yield return new WaitForSeconds(0.25f);
    SwordS2 = false;
    rotX = 0;
    rotY = 0;
    rotZ = 0;
    }
}
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
    private float reloadRot;
    private bool reloadDone;
    private AudioSource SCARAudio;
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public GameObject shootParticlePrefab;
    public TeleportManager teleportManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        SCARAudio = GetComponent<AudioSource>();
        magSize = 30;
        reloadRot = 0;
        reloadDone = false;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        shootTime = shootTime + Time.deltaTime;
        transform.position = Player.transform.position + offset;
        transform.rotation = Player.transform.rotation;
        transform.position += transform.right;
        transform.position += transform.forward;
        if (magSize <= 0 && reloadDone == false && !teleportManagerScript.isPowerActive)
        {
            transform.Rotate(reloadRot, 0, 0);
            reloadRot = reloadRot - 60f * Time.deltaTime;
            if (reloadRot <= -45)
            {
                reloadRot = -45;
            }
        }
        if (Input.GetKey(KeyCode.Mouse0) && shootTime > 0.2 && magSize > 0)
        {
            Vector3 offset2 = transform.up * 0.5f + transform.forward * 8f;
            shootTime = 0;
            SCARAudio.PlayOneShot(shootSound, 1.0f);
            Instantiate(projectilePrefab, transform.position + offset2, transform.rotation);
            magSize = magSize - 1;
            StartCoroutine(MagCheck());
            Instantiate(shootParticlePrefab, transform.position + offset2, transform.rotation);
        }
        if (reloadDone == true)
        {
            transform.Rotate(reloadRot, 0, 0);
            reloadRot = reloadRot + 60f * Time.deltaTime;
            if (reloadRot >= 0)
            {
                reloadRot = 0;
            }
        }
    }
    IEnumerator MagCheck() {
        if (magSize <= 0)
        {
            SCARAudio.PlayOneShot(reloadSound, 1.0f);
            yield return new WaitForSeconds(3.25f);
            SCARAudio.PlayOneShot(reloadSound, 1.0f);
            StartCoroutine(DownGun());
        }
    }
    IEnumerator DownGun()
    {
        reloadDone = true;
        yield return new WaitForSeconds(0.75f);
        reloadRot = 0;
        magSize = 30;
        reloadDone = false;
    }
}

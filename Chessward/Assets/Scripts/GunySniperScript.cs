using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunySniperScript : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset = new Vector3(0, 15, 0);
    public GameObject projectilePrefab;
    private float shootTime;
    public int magSize;
    private float reloadRot;
    private bool reloadDone;
    private AudioSource SniperAudio;
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public GameObject shootParticlePrefab;
    public TeleportManager teleportManagerScript;
    private bool manualReload = false;
    // Start is called before the first frame update
    void Start()
    {
        SniperAudio = GetComponent<AudioSource>();
        magSize = 3;
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
        if (magSize <= 0 && reloadDone == false)
        {
            transform.Rotate(reloadRot, 0, 0);
            reloadRot = reloadRot - 60f * Time.deltaTime;
            if (reloadRot <= -45)
            {
                reloadRot = -45;
            }
        }
        if (Input.GetKey(KeyCode.Mouse0) && shootTime > 4 && magSize > 0 && !teleportManagerScript.isPowerActive)
        {
            Vector3 offset2 = transform.up * 0.5f + transform.forward * 12f;
            shootTime = 0;
            SniperAudio.PlayOneShot(shootSound, 1.4f);
            Instantiate(projectilePrefab, transform.position + offset2, transform.rotation);
            magSize = magSize - 1;
            StartCoroutine(MagCheck());
            Instantiate(shootParticlePrefab, transform.position + offset2, transform.rotation);
            SniperAudio.PlayOneShot(reloadSound, 1.0f);
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
        transform.Rotate(-90, 90, 0);
        if (Input.GetKey(KeyCode.R) && !manualReload)
        {
            magSize = 0;
            StartCoroutine(MagCheck());
        }
    }
    IEnumerator MagCheck() {
        if (magSize <= 0)
        {
            manualReload = true;
            SniperAudio.PlayOneShot(reloadSound, 1.0f);
            yield return new WaitForSeconds(8.25f);
            SniperAudio.PlayOneShot(reloadSound, 1.0f);
            StartCoroutine(DownGun());
            manualReload = false;
        }
    }
    IEnumerator DownGun()
    {
        reloadDone = true;
        yield return new WaitForSeconds(0.75f);
        reloadRot = 0;
        magSize = 3;
        reloadDone = false;
    }
}

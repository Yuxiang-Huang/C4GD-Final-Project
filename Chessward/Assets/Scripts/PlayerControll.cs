using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float jumpForce = 100.0f;
    private Rigidbody playerRb;
    public bool isOnGround = true;
    public float gravityModifier;
    private float speed = 20.0f;
    private float rSpeed = 700.0f;
    public int health;
    private int damage;
    private AudioSource PlayerAudio;
    public bool gameOver;
    public AudioClip jumpSound;
    public AudioClip landSound;
    public TeleportManager teleportManager;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        health = 1000;

        switch (teleportManager.pieceName)
        {
            case "Rook":
                health = 150;
                break;
            case "Knight":
                health = 150;
                break;
            case "Bishop":
                health = 200;
                break;
            case "Queen":
                health = 100;
                break;
            case "Pawn":
                health = 200;
                break;
            case "King":
                health = 200;
                break;
        }

        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRb.AddRelativeForce(new Vector3(horizontalInput * speed, 0, forwardInput * speed), ForceMode.VelocityChange);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            PlayerAudio.PlayOneShot(jumpSound, 1.0f);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (!teleportManager.isPowerActive)
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rSpeed);
        }
            

        if (health <= 0)
        {
            gameOver = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isOnGround == false)
            {
                PlayerAudio.PlayOneShot(landSound, 1.0f);
            }
            isOnGround = true;
        }      
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletBad"))
        {
            health = health - damage;
        }
    }
}

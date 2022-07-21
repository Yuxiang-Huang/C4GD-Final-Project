using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float ammo;
    public Guny gunyScript;
    public PlayerControll playercontrollScript;
    public TextMeshProUGUI ammoText;
    private float health;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI ShotGunAmmoText;
    private float sAmmo;
    public GunyShotGun sgunyScript;
    // Start is called before the first frame update
    void Start()
    {
        UpdateAmmo(30);
        UpdateHealth(100);
        UpdateSAmmo(6);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmo(gunyScript.magSize);
        UpdateHealth(playercontrollScript.health);
        UpdateSAmmo(playercontrollScript.health);
    }
    public void UpdateAmmo(int ammoLeft)
    {
        ammo = gunyScript.magSize;
        ammoText.text = "Ammo: " + ammo;
        if (ammo == 0)
        {
            ammoText.text = "Reloading";
        }
    }
    public void UpdateHealth(int healthLeft)
    {
        health = playercontrollScript.health;
        healthText.text = "Health: " + health;
        if (health <= 0)
        {
            healthText.text = "Game Over";
        }
    }
    public void UpdateSAmmo(int sAmmoLeft)
    {
        sAmmo = sgunyScript.magSize;
        ShotGunAmmoText.text = "Ammo: " + sAmmo;
        if (sAmmo == 0)
        {
            ShotGunAmmoText.text = "Reloading";
        }
    }
}

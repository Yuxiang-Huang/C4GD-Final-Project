using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float ammo;
    public TextMeshProUGUI ammoText;
    public Guny gunyScript;

    private float SMGammo;
    public TextMeshProUGUI SMGText;
    public SMGguny SMGgunyScript;

    public GunySniperScript sniperScript;
    private float snAmmo;
    public TextMeshProUGUI SniperAmmoText;

    public PlayerControll playercontrollScript;
    private float health;
    public TextMeshProUGUI healthText;

    public TextMeshProUGUI ShotGunAmmoText;
    private float sAmmo;
    public GunyShotGun sgunyScript;

    public TextMeshProUGUI RevolverText;
    private float rAmmo;
    public RevolverGuny rgunyScript;
    // Start is called before the first frame update
    void Start()
    {
        UpdateAmmo(30);
        UpdateHealth(100);
        UpdateSAmmo(6);
        UpdateSNAmmo(5);
        UpdateRAmmo(6);
        UpdateSMGAmmo(50);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmo(gunyScript.magSize);
        UpdateHealth(playercontrollScript.health);
        UpdateSAmmo(sgunyScript.magSize);
        UpdateSNAmmo(sniperScript.magSize);
        UpdateRAmmo(rgunyScript.magSize);
        UpdateSMGAmmo(SMGgunyScript.magSize);
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
    public void UpdateSNAmmo(int snAmmoLeft)
    {
        snAmmo = sniperScript.magSize;
        SniperAmmoText.text = "Ammo: " + snAmmo;
        if (snAmmo == 0)
        {
            SniperAmmoText.text = "Reloading";
        }
    }
    public void UpdateRAmmo(int rAmmoLeft)
    {
        rAmmo = rgunyScript.magSize;
        RevolverText.text = "Ammo: " + rAmmo;
        if (rAmmo == 0)
        {
            RevolverText.text = "Reloading";
        }
    }
    public void UpdateSMGAmmo(int SMGAmmoLeft)
    {
        SMGammo = SMGgunyScript.magSize;
        SMGText.text = "Ammo: " + SMGammo;
        if (SMGammo == 0)
        {
            SMGText.text = "Reloading";
        }
    }
}

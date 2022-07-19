using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float ammo;
    public Guny gunyScript;
    public TextMeshProUGUI ammoText;
    // Start is called before the first frame update
    void Start()
    {
        gunyScript = GameObject.Find("SCAR").GetComponent<Guny>();
        UpdateAmmo(30);
        ammoText = GameObject.Find("ammoText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmo(gunyScript.magSize);
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
}

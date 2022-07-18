using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEasyControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float VInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * VInput * 5);
    }
}

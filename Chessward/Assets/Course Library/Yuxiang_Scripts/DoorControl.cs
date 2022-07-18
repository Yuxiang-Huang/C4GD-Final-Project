using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorControl : MonoBehaviour
{
    bool doorClose;
    public Button open;
    public Button close;

    // Start is called before the first frame update
    void Start()
    {
        doorClose = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (doorClose)
        {
            open.gameObject.SetActive(true);
        }

        else
        {
            close.gameObject.SetActive(true);
        }
    }

    public void openDoor ()
    {
        gameObject.SetActive(true);
        open.gameObject.SetActive(false);
        doorClose = false;
    }

    public void closeDoor()
    {
        gameObject.SetActive(false);
        close.gameObject.SetActive(false);
        doorClose = true;
    }
}

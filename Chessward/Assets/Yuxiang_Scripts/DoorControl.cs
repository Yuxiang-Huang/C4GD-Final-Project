using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorControl : MonoBehaviour
{
    bool doorClose;
    public Button open;
    public Button close;
    public GameObject doorLeft;
    public GameObject doorRight;
    public bool interactable = false;

    // Start is called before the first frame update
    void Start()
    {
        doorClose = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable && Input.GetKeyDown(KeyCode.O))
        {

            if (doorClose)
            {
                open.onClick.Invoke();
            }

            else
            {
                close.onClick.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (doorClose)
            {
                open.gameObject.SetActive(true);
            }

            else
            {
                close.gameObject.SetActive(true);
            }
            interactable = true;
        }      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")){
            if (doorClose)
            {
                open.gameObject.SetActive(false);
            }

            else
            {
                close.gameObject.SetActive(false);
            }

            interactable = false;
        }
    }

    public void openDoor ()
    {
        doorLeft.gameObject.SetActive(false);
        doorRight.gameObject.SetActive(false);
        open.gameObject.SetActive(false);
        doorClose = false;
        close.gameObject.SetActive(true);
    }

    public void closeDoor()
    {
        doorLeft.gameObject.SetActive(true);
        doorRight.gameObject.SetActive(true);
        close.gameObject.SetActive(false);
        doorClose = true;
        open.gameObject.SetActive(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}

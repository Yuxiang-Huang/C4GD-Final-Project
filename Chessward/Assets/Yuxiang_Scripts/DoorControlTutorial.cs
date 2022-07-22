using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorControlTutorial : MonoBehaviour
{
    bool doorClose;
    public Button open;
    public Button close;
    public GameObject doorLeft;
    public GameObject doorRight;
    public bool interactable = false;

    public GameObject FirstDirection;
    public GameObject SecondDirection;
    public GameObject ThirdDirection;
    public GameObject FourthDirection;

    bool readyForDirection;
    bool lastPatch;

    // Start is called before the first frame update
    void Start()
    {
        FirstDirection = GameObject.Find("First Direction");
        SecondDirection = GameObject.Find("Second Direction");
        ThirdDirection = GameObject.Find("Third Direction");
        FourthDirection = GameObject.Find("Fourth Direction");

        doorClose = true;
        FirstDirection.SetActive(true);
        SecondDirection.SetActive(false);
        ThirdDirection.SetActive(false);
        FourthDirection.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.Q))
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

        if (lastPatch && readyForDirection)
        {
            ThirdDirection.SetActive(false);
            FourthDirection.SetActive(true);
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

            if (FirstDirection.activeSelf)
            {
                FirstDirection.SetActive(false);
                SecondDirection.SetActive(true);
            }         
        }      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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



        lastPatch = true;
    }

    public void openDoor()
    {
        doorLeft.gameObject.SetActive(false);
        doorRight.gameObject.SetActive(false);
        open.gameObject.SetActive(false);
        doorClose = false;
        close.gameObject.SetActive(true);
        if (SecondDirection.activeSelf)
        {
            SecondDirection.SetActive(false);
            ThirdDirection.SetActive(true);
            StartCoroutine(waitForTime());
        }
    }

    public void closeDoor()
    {
        doorLeft.gameObject.SetActive(true);
        doorRight.gameObject.SetActive(true);
        close.gameObject.SetActive(false);
        doorClose = true;
        open.gameObject.SetActive(true);
    }

    IEnumerator waitForTime()
    {
        yield return new WaitForSeconds(3);
        readyForDirection = true;
    }
}


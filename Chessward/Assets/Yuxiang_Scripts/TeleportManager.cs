using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportManager : MonoBehaviour
{
    private GameObject player;

    public Button[] Rank1 = new Button[8];
    public Button[] Rank2 = new Button[8];
    public Button[] Rank3 = new Button[8];

    public Button[][] allButtons;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

       allButtons = new Button[][] {Rank1, Rank2, Rank3};

        foreach (Button[] rank in allButtons)
        {
            foreach (Button button in rank)
            {
                button.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FindSquareForKnight()
    {

    }
}

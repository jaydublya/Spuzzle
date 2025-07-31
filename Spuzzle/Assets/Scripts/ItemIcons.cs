using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemIcons : MonoBehaviour
{
    public List<GameObject> collectables;
    private GameManager gameManager;
    public GameObject batteryIcon;
    public GameObject metalIcon;
    public GameObject wireIcon;
    public GameObject tapeIcon;
    public GameObject cogIcon;
    public bool batteryCollected;
    public bool metalCollected;
    public bool wireCollected;
    public bool tapeCollected;
    public bool cogCollected;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (batteryCollected)
            {
                batteryIcon.SetActive(true);
            } else if(metalCollected)
            {
                metalIcon.SetActive(true);
            } else if (wireCollected)
            {
                wireIcon.SetActive(true);
            } else if (tapeCollected)
            {
                tapeIcon.SetActive(true);
            } else if (cogCollected)
            {
                cogIcon.SetActive(true);
            }


        }
    }
}

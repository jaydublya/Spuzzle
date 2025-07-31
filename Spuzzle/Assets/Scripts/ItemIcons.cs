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
    public float metalVariable;
    public float batteryVariable;
    public float wireVariable;
    public float tapeVariable;
    public float cogVariable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ItemGained()
    {
        if (gameManager.isGameActive && !gameManager.isGamePaused)
        {
            if (batteryCollected)
            {
                batteryIcon.SetActive(true);
                batteryVariable = 1;
                Debug.Log("Battery Collected");
            }
            else if (metalCollected)
            {
                metalIcon.SetActive(true);
                metalVariable = metalVariable + 1;
                Debug.Log("Metal Collected");
            }
            else if (wireCollected)
            {
                wireIcon.SetActive(true);
                wireVariable = wireVariable + 1;
                Debug.Log("Wires Collected");
            }
            else if (tapeCollected == true)
            {
                tapeIcon.SetActive(true);
                tapeVariable = 1;
                Debug.Log("Duck Tape Collected");
            }
            else if (cogCollected)
            {
                cogIcon.SetActive(true);
                cogVariable += 1;
                Debug.Log("Cogwheel Collected");
            }

        }
    }

}

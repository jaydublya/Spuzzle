using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemIcons : MonoBehaviour
{
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

    public enum ItemType
    {
        Battery,
        Metal,
        Wire,
        Tape,
        Cog
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ItemGained(ItemType type)
    {
        if (gameManager.isGameActive && !gameManager.isGamePaused)
        {
            if (type == ItemType.Battery)
            {
                batteryIcon.SetActive(true);
                batteryVariable = 1;
                Debug.Log("Battery Collected");
            }
            else if (type == ItemType.Metal)
            {
                metalIcon.SetActive(true);
                metalVariable = metalVariable + 1;
                Debug.Log("Metal Collected");
            }
            else if (type == ItemType.Wire)
            {
                wireIcon.SetActive(true);
                wireVariable = wireVariable + 1;
                Debug.Log("Wires Collected");
            }
            else if (type == ItemType.Tape)
            {
                tapeIcon.SetActive(true);
                tapeVariable = 1;
                Debug.Log("Duck Tape Collected");
            }
            else if (type == ItemType.Cog)
            {
                cogIcon.SetActive(true);
                cogVariable += 1;
                Debug.Log("Cogwheel Collected");
            }

        }
    }

}

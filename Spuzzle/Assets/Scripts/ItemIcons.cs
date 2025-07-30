using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemIcons : MonoBehaviour
{
    public List<GameObject> collectables;
    private GameManager gameManager;
    

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
            
           
        }
    }
}

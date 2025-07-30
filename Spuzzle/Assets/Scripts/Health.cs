using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        health = gameManager.healthPoints;
    }

    // Update is called once per frame
    void Update()
    {

    }

}

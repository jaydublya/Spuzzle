using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UI;

public class RestartButton : MonoBehaviour
{
    private GameManager gameManager;
    public Button restartButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        restartButton = GetComponent<Button>();
    }
}

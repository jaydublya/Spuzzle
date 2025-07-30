using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UI;

public class ContinueButton : MonoBehaviour
{
    private GameManager gameManager;
    public Button continueButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        continueButton = GetComponent<Button>();
    }

}

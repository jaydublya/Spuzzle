using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public bool isGameActive;
    public int itemsCollected;
    public GameObject pauseMenu;
    
    //This Script will start the game when the Start Button is clicked, end the game when the Quit Button is clicked, will make the game restart when the restart button is clicked, and will make the Game Over screen appear when Gluey is dead
   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGameActive = false;
        titleScreen.SetActive(true);
        itemsCollected = 0;
        pauseMenu.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            titleScreen.SetActive(false);
        }
    }
}

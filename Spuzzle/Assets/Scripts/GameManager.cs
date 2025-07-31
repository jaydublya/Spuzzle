using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public bool isGameActive;
    public int itemsCollected;
    public GameObject pauseMenu;
    public GameObject gameOverScreen;
    public int healthPoints = 5;
    public bool isGamePaused;
    public GameObject restartButton;
    public TextMeshProUGUI healthText;
    private ItemIcons itemIcon;

    public AudioClip songTwo;
    public AudioSource speaker;
    
    //This Script will start the game when the Start Button is clicked, end the game when the Quit Button is clicked, will make the game restart when the restart button is clicked, and will make the Game Over screen appear when Gluey is dead
   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGameActive = false;
        titleScreen.SetActive(true);
        itemsCollected = 0;
        pauseMenu.SetActive(false);
        gameOverScreen.SetActive(false);
        isGamePaused = false;
        itemIcon = GameObject.Find("Collectables").GetComponent<ItemIcons>();
        itemIcon.batteryIcon.SetActive(false);
        itemIcon.metalIcon.SetActive(false);
        itemIcon.wireIcon.SetActive(false);
        itemIcon.tapeIcon.SetActive(false);
        itemIcon.cogIcon.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            titleScreen.SetActive(false);
            healthText.text = "Health: " + healthPoints;

        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.gameObject.SetActive(true);
        Debug.Log("Game Over");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Game Restarted");
    }

    public void StartGame()
    {
        isGameActive=true;
        Debug.Log("Game Start");
    }

    public void QuitGame()
    {
        Debug.Log("Game Ended");
        isGameActive = false;
        isGamePaused = false;
    }

    public void PauseGame()
    {
        isGamePaused = true;
        isGameActive = false;
        pauseMenu.SetActive(true);
        Debug.Log("Game Paused");
    }


    public void ContinueGame()
    {
        isGamePaused=false;
        isGameActive=true;
        Debug.Log("Game Unpaused");
        pauseMenu.SetActive(false);
    }
    public void SwitchMusicTrack()
    {
        speaker.Stop();
        speaker.clip = songTwo;
        speaker.Play();
    }


}

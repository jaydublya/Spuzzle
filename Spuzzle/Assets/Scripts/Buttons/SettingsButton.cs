using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    private GameManager gameManager;
    private ItemIcons itemIcon;
    public GameObject cogWheel;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        itemIcon = GameObject.Find("Collectables").GetComponent<ItemIcons>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingsButtonClicked()
    {
        Debug.Log("Settings Button Clicked");
        if (!itemIcon.cogCollected)
        {
            Instantiate(cogWheel);
            cogWheel.transform.Translate(1,0,0);
        }
    }

}

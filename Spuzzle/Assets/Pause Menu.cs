using System;

public class PauseMenu : MonoBehavior
{
	public GameObject PausePanel;
	
	void Update()
	{

	}
	public void Pause()
    {
		PausePanel.SetActive(true);
		Time.timeScale = 0;
    }
	public void Continue()
    {
		PausePanel.SetActive(false);
		Time.timeScale = 1;
    }
}

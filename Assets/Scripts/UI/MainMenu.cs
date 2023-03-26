using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
    public GameObject CreditsSheet;
	public bool isCredits;
   
	public GameObject Settings;
	public bool isSettings;
	
	public MenuSFX source;


	public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
	

	
	void Start()
	{
		CreditsSheet.SetActive(false);
		Settings.SetActive(false);

		isCredits = false;
		isSettings = false;
		
		source = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<MenuSFX>();
	}
	
	void Update()
	{
		if((Input.GetKeyDown(KeyCode.Escape)))
		{
			if(isCredits)
			{
				CloseCreditsPage();
			} else if(isSettings)
			{
				CloseSettingsPage();
			}
		}
	}

	
	public void CreditsPage()
    {
		source.PlayPF1();
        CreditsSheet.SetActive(true);
		isCredits = true;
    }
	
		
	
	public void CloseCreditsPage()
    { 
		source.PlayPF2();
        CreditsSheet.SetActive(false);
		isCredits = false;
    }




		public void SettingsPage()
    {
		source.PlayPF1();
        Settings.SetActive(true);
		isSettings = true;
    }
	
		
	
	public void CloseSettingsPage()
    { 
		source.PlayPF2();
        Settings.SetActive(false);
		isSettings = false;
    }
}
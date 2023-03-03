using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject player;
    private CharacterController cc;
    private LookController lc;


    void Start()
    {
        lc = player.GetComponentInChildren<LookController>();
        cc = player.GetComponent<CharacterController>();
        Debug.Log(lc);
    }

    // Update is called once per frame
    public void Update()
    {

        // int activeScene = SceneManager.GetActiveScene().buildIndex;
        // Debug.Log(activeScene);
        // if (activeScene != 0) {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape pressed");

            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        // }
    }

    void Resume()
    {
        Debug.Log("resumed");
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("paused");


        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }

    }

}
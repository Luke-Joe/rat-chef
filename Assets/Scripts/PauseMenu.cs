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


    // Update is called once per frame
    public void Update()
    {

        // int activeScene = SceneManager.GetActiveScene().buildIndex;
        // Debug.Log(activeScene);
        // if (activeScene != 0) {

        if (Input.GetKeyDown(KeyCode.Escape)) {
                    Debug.Log("escape pressed");

            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
        // }
    }

    void Resume() {
        Debug.Log("resumed");

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
         AudioSource[] audios = FindObjectsOfType<AudioSource>();

        // foreach (AudioSource a in audios) {
        //     a.Play();
        // }
    }

    void Pause() {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("paused");

         AudioSource[] audios = FindObjectsOfType<AudioSource>();

        // foreach (AudioSource a in audios) {
        //     a.Pause();
        // }

    }
    
}

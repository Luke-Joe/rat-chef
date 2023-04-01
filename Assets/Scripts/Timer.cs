using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Recipe recipe;
    [SerializeField]
    private TextMeshProUGUI countdown;

    private float currentTime = 0f;
    private float startingTime;
    private float minutes;
    private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        startingTime = recipe.time;
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        minutes = Mathf.Floor(currentTime / 60);
        seconds = currentTime % 60;

        countdown.text = minutes.ToString("0") + ":" + seconds.ToString("00");

        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }
}

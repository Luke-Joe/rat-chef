using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        countdown.text = minutes.ToString("0") + ":" + seconds.ToString("0");

        Debug.Log("Minutes: " + minutes + "Seconds: " + seconds);
        if (currentTime <= 0)
        {
            currentTime = 0;
            Debug.Log("Out of Time");
        }


    }
}

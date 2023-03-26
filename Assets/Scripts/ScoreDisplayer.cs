using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplayer : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private FinishLevel finishLevel;

    void Start()
    {
        finishLevel = GameObject.FindGameObjectsWithTag("End")[0].GetComponent<FinishLevel>();
    }

    void Update()
    {
        scoreText.text = ((int)(finishLevel.finalScore * 100)).ToString();
    }
}

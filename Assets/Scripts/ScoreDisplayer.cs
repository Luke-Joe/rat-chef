using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplayer : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private FinishLevel finishLevel;

    public Image[] stars;
    public Sprite fullStar;
    public Sprite emptyStar;

    private int totalStars;
    private float score;

    void Start()
    {
        finishLevel = GameObject.FindGameObjectsWithTag("End")[0].GetComponent<FinishLevel>();
        totalStars = 5;
        score = finishLevel.finalScore * 100.0f;
    }

    void Update()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (score > 0)
            {
                stars[i].sprite = fullStar;
                score -= (100 / totalStars);
            }
            else
            {
                stars[i].sprite = emptyStar;
            }

            // scoreText.text = ((int)(finishLevel.finalScore * 100)).ToString();
        }
    }
}

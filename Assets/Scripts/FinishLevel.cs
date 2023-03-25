using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public GameObject endZone;

    public float finalScore;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        finalScore = endZone.GetComponent<Rating>().RateIngredients();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

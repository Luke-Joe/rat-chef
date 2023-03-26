using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ratPrefab;

    [SerializeField] private float spawnInterval;

    void Start()
    {

    }

    void Update()
    {

    }

    public void SpawnRat()
    {
        GameObject newRat = Instantiate(ratPrefab, this.transform.position, Quaternion.identity);
    }

    public void SpawnRat(Transform targetFood)
    {
        GameObject newRat = Instantiate(ratPrefab, this.transform.position, Quaternion.identity);
        newRat.GetComponent<RatController>().food = targetFood;
    }


}

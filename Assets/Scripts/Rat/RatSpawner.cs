using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ratPrefab;

    [SerializeField] private float spawnInterval;
    public Transform despawnZone;
    private float currSpawn;


    void Start()
    {
        currSpawn = spawnInterval;
    }

    void Update()
    {
        currSpawn -= Time.deltaTime;

        if (currSpawn <= 0)
        {
            SpawnRat();
            currSpawn = spawnInterval;
        }
    }

    public void SpawnRat()
    {
        GameObject newRat = Instantiate(ratPrefab, this.transform.position, Quaternion.identity);
        RatController rc = newRat.GetComponent<RatController>();
        rc.home = this.transform;
        rc.despawnZone = this.despawnZone;
    }

    public void SpawnRat(Transform targetFood)
    {
        GameObject newRat = Instantiate(ratPrefab, this.transform.position, Quaternion.identity);
        RatController rc = newRat.GetComponent<RatController>();
        rc.food = targetFood;
        rc.home = this.transform;
        rc.despawnZone = this.despawnZone;
    }


}

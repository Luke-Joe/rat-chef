using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ratPrefab;

    [SerializeField] private float spawnInterval;
    public Transform despawnZone;
    private bool _spawning = true;

    void Start()
    {
        StartCoroutine(SpawnRat()); 

    }

    void Update()
    {

        {
            
        }
    }

   IEnumerator SpawnRat()
   {
    while (_spawning == true)
    {
        yield return new WaitForSeconds(3); // wait 3 sec
        GameObject newRat = Instantiate(ratPrefab, this.transform.position, Quaternion.identity);
        RatController rc = newRat.GetComponent<RatController>();
       // rc.home = this.transform;
        //rc.despawnZone = this.despawnZone;
        yield return new WaitForSeconds(10);
    }
    }

    public void SpawnRat(Transform targetFood)
    {
        GameObject newRat = Instantiate(ratPrefab, this.transform.position, Quaternion.identity);
        newRat.GetComponent<RatController>().food = targetFood;
        RatController rc = newRat.GetComponent<RatController>();
        rc.food = targetFood;
        rc.home = this.transform;
        rc.despawnZone = this.despawnZone;
    }


}

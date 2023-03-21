using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePour : MonoBehaviour
{
    // Pour Threshold Ranges from -56 to 56 
    // -56 for object pointing straight down, 56 for straight up, 0 for sideways
    public int pourThreshold = 10;
    public Transform origin = null;
    public ParticleSystem ps = null;
    private ParticleSystem currPs = null;
    // public float pourAngle = 0;

    [SerializeField]
    private Seasoning seasoning;

    private bool isPouring = false;

    void Update()
    {
        bool pourCheck = CalculatePourAngle() < pourThreshold;

        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                Pour();
            }
            else
            {
                StopPour();
            }
        }

        if (isPouring)
        {
            if (currPs != null)
            {
                UpdatePour();
            }

            FindEndPoint();
        }

    }

    void Pour()
    {
        currPs = Instantiate(ps, origin.transform.position, ps.transform.rotation);
        currPs.Play();
    }

    void FindEndPoint()
    {
        RaycastHit hit;
        Ray ray = new Ray(origin.transform.position, Vector3.down);

        Physics.Raycast(ray, out hit, 15f);

        if (hit.transform.gameObject)
        {
            GameObject collision = hit.transform.gameObject;

            if (collision.GetComponent<IngredientHandler>() != null)
            {
                IngredientHandler ingredientFound = collision.GetComponent<IngredientHandler>();
                Debug.Log(ingredientFound); // I don't know why but this line of code is needed otherwise an error occurs

                if (ingredientFound.seasonings.ContainsKey(seasoning.seasoningName))
                {
                    ingredientFound.seasonings.TryGetValue(seasoning.seasoningName, out Seasoning seasoningFound);
                    seasoningFound.quantity += 1;
                    Debug.Log(seasoningFound.quantity + seasoningFound.seasoningName);
                }
                else
                {
                    ingredientFound.seasonings.Add(seasoning.seasoningName, seasoning);
                }
            }
        }
    }

    void UpdatePour()
    {
        if (Vector3.Distance(origin.transform.position, currPs.transform.position) >= 0.02f)
        {
            currPs.Stop();
            currPs = Instantiate(ps, origin.transform.position, ps.transform.rotation);
        }
    }

    void StopPour()
    {
        if (currPs != null)
        {
            currPs.Stop();
        }
    }

    private float CalculatePourAngle()
    {
        return transform.up.y * Mathf.Rad2Deg;
    }
}

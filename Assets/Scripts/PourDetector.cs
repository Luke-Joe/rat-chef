using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    // Pour Threshold Ranges from -56 to 56 
    // -56 for object pointing straight down, 56 for straight up, 0 for sideways
    public int pourThreshold = 10;
    public Transform origin = null;
    public GameObject streamPrefab = null;
    // public float pourAngle = 0;

    private bool isPouring = false;
    private Stream currentStream = null;

    void Update()
    {
        bool pourCheck = CalculatePourAngle() > pourThreshold;
        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }
    }

    void StartPour()
    {
        currentStream = CreateStream();
        currentStream.Begin();
    }

    void EndPour()
    {
        currentStream.End();
        currentStream = null;
    }

    private float CalculatePourAngle()
    {
        return transform.up.y * Mathf.Rad2Deg;
    }

    private Stream CreateStream()
    {
        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return streamObject.GetComponent<Stream>();
    }
}

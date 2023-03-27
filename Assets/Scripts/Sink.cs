using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public Transform origin = null;
    public GameObject streamPrefab = null;
    public GameObject waterCollider = null;

    public bool isActive = false;
    private Stream currentStream = null;

    AudioSource audioSource;

    public SFXPlaying source;
        void Start()
     {
        source = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<SFXPlaying>();
    }

    void Update()
    {
        if (isActive)
        {
            if (currentStream == null)
            {
                StartPour();
                
                
            }
        }
        else
        {
            EndPour();
            source.StopWater();
            
        }
    }

    void StartPour()
    {
        source.PlayWater();
        currentStream = CreateStream();
        currentStream.Begin();
        waterCollider.GetComponent<BoxCollider>().enabled = true;
    }

    void EndPour()
    {
        if (currentStream != null)
        {
            currentStream.End();
            currentStream = null;
            waterCollider.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private Stream CreateStream()
    {
        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity);
        return streamObject.GetComponent<Stream>();
    }

    public void ToggleSink()
    {
        this.isActive = !this.isActive;
    }
}

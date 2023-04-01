using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    [SerializeField] private RectTransform crosshair;

    public float currentSize = 30f;
    public float idleSize = 30f;
    public float actionSize = 20f;
    public float jumpSize = 30f;
    public float speed = 15f;
public GameObject TabMenuM;
    public SFXPlaying source;
    
    // Start is called before the first frame update
    void Start()
    {
        TabMenuM.SetActive(false);
        source = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<SFXPlaying>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            currentSize = Mathf.Lerp(currentSize, actionSize, Time.deltaTime * speed);
        }
        else
        {
            currentSize = Mathf.Lerp(currentSize, idleSize, Time.deltaTime * speed);
        }

        crosshair.sizeDelta = new Vector2(currentSize, currentSize);

        if (Input.GetButton("Fire2"))
        {
            crosshair.GetComponentInChildren<Image>().color = Color.green;
        }
        else
        {
            crosshair.GetComponentInChildren<Image>().color = Color.white;
        }


         if((Input.GetKeyDown(KeyCode.Tab)))
        {
            source.PlayPF2();
            
        }
        if((Input.GetKeyUp(KeyCode.Tab)))
        {
            source.PlayPF1();
            
        }

         if((Input.GetKey(KeyCode.Tab)))
        {
            TabMenuM.SetActive(true);
            
        } else
        {
            TabMenuM.SetActive(false);
            
        }
    }
}

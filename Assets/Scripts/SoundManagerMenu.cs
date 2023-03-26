/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerMenu : MonoBehaviour
{

    public static AudioClip PaperFlip1Sound, PaperFlip2Sound, PaperFlip3Sound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        PaperFlip1Sound = Sounds.Load<AudioClip> ("PaperFlip1");
        PaperFlip2Sound = Sounds.Load<AudioClip> ("PaperFlip2");
        PaperFlip3Sound = Sounds.Load<AudioClip> ("PaperFlip3");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void PlaySound (string clip)
    {
    

            switch (clip){
                case "PaperFlip1":
                    audioSrc.PlayOneShot (PaperFlip1Sound);
                    break;

                case "PaperFlip2":
                    audioSrc.PlayOneShot (PaperFlip2Sound);
                    break;

                case "PaperFlip3":
                    audioSrc.PlayOneShot (PaperFlip3Sound);
                    break;

            }
        
        
    }
}


*/

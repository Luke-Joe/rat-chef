using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    // [SerializeField] Slider volumeSlider;

    public void ChangeVolume(float volumeSlider) {
        mixer.SetFloat("volume", Mathf.Log10 (volumeSlider) * 20);
    }
    // void Start () {
    //     if (!PlayerPrefs.HasKey("musicVolume")) {
    //         PlayerPrefs.SetFloat("musicVolume", 1);
    //         Load();
    //     } else {
    //         Load();
    //     }
    //     // audioMixer.SetFloat("volume", volume);
    //     // AudioListener.volume = volumeSlider.value;


    // } 

    // public void ChangeVolume() {
    //     AudioListener.volume = volumeSlider.value;
    //     Save();

    // }

    // private void Load() {
    //     volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    // }

    // private void Save() {
    //     PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    // }
}

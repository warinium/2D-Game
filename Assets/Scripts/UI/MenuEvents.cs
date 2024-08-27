using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuEvents : MonoBehaviour
{

    public Slider volumeSlider;
    public AudioMixer audioMixer;

    private float soundVolumeValue;


    public void LoadLevel(int index)
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        
        SceneManager.LoadScene(index);
        
        Time.timeScale = 1;
        AudioManager.instance.Play("BackGroundSound");
    }

    public void SetVolume()
    {
        audioMixer.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);

    }

    private void Start()
    {

        PlayerPrefs.GetFloat("Volume", 80);

        //audioMixer.GetFloat("Volume", out soundVolumeValue);
        soundVolumeValue=PlayerPrefs.GetFloat("Volume", 80);

        volumeSlider.value = soundVolumeValue;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

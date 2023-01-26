using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MusicPlayer : MonoBehaviour
{
    // Music Variables
    private AudioSource audioSource;
    public GameObject musicAudio;
    private float musicVolume = 1f;

    public Slider slider;

    private string volumeFile = "volume.txt";

    // Start is called before the first frame update
    void Start()
    {
        musicAudio = GameObject.FindWithTag("Music");
        audioSource = musicAudio.GetComponent<AudioSource>();
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            if (File.Exists(volumeFile))
            {
                string fileText = File.ReadAllText(volumeFile);
                float.TryParse(fileText, out musicVolume);
            }
            else
            {
                musicVolume = 0.5f;
            }
        }
        else
        {
            if (PlayerPrefs.HasKey("volume"))
                musicVolume = PlayerPrefs.GetFloat("volume");
        }
        audioSource.volume = musicVolume;
        slider.value = musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolume;
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            File.WriteAllText(volumeFile, musicVolume.ToString());
        }
        else
        {
            PlayerPrefs.SetFloat("volume", musicVolume);
        }
    }
}

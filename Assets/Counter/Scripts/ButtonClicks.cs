using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClicks : MonoBehaviour
{
    // Game Manager
    public float timerValue = 60.0f;
    public float spawnRateValue = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        PlayerPrefs.SetFloat("timeRemaining", timerValue);
        PlayerPrefs.SetFloat("spawnRate", spawnRateValue);
        SceneManager.LoadScene("Game");
    }
}

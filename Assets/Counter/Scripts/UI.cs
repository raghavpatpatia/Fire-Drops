using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Game Objects in UI Scene
    public GameObject startWindow;
    public GameObject difficultyWindow;
    public GameObject optionWindow;

    // Start is called before the first frame update
    void Start()
    {
        startWindow.SetActive(true);
        difficultyWindow.SetActive(false);
        optionWindow.SetActive(false);
        
    }

    public void OnStartButtonClick()
    {
        startWindow.SetActive(false);
        difficultyWindow.SetActive(true);
    }

    public void OnOptionButtonClick()
    {
        startWindow.SetActive(false);
        optionWindow.SetActive(true);
    }

    public void OnBackButtonClick()
    {
        optionWindow.SetActive(false);
        startWindow.SetActive(true);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}

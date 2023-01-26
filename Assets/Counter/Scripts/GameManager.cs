using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    // Player Game Object
    public GameObject player;

    // Pause Screen
    public GameObject pauseScreen;
    private bool isPaused;
    public GameObject pauseButton;

    // Time Variables
    private float timeRemaining;
    public Text timerText;
    public Text timerTextHighlight;

    // Spawning Variables
    public GameObject spawner;
    public float zRange;
    public bool isGameOver = false;
    private float spawnRate = 1.0f;

    // Counter variables
    public ParticleSystem particle;
    public GameObject gameOverScreen;
    public Text winLoseText;
    public Text winLoseTextHighlight;
    private Counter counter;

    public String[] value = { "Win", "Lose" };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = PlayerPrefs.GetFloat("timeRemaining", 60.0f);
        spawnRate = PlayerPrefs.GetFloat("spawnRate", 1.0f);

        StartCoroutine(SpawnTarget());

        counter = FindObjectOfType<Counter>();
        particle = FindObjectOfType<ParticleSystem>();
        gameOverScreen.SetActive(false);
        particle.Stop();

        pauseScreen.SetActive(false);
    }

    public void OnPauseButtonClick()
    {
        Paused();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            timeRemaining -= Time.time;
            timerText.text = string.Format("Time: {0}", (int)timeRemaining);
            timerTextHighlight.text = string.Format("Time: {0}", (int)timeRemaining);
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused();
        }
    }

    void GameOver()
    {
        if (timeRemaining <= 0)
        {
            isGameOver = true;
            Destroy(player);
            gameOverScreen.SetActive(true);
            pauseButton.SetActive(false);
            LoseText("You Lose");
        }
        else if (counter.Count == 100 && timeRemaining != 0)
        {
            isGameOver = true;
            Destroy(player);
            particle.Play();
            Destroy(particle.gameObject, 8f);
            gameOverScreen.SetActive(true);
            pauseButton.SetActive(false);
            WinText("You Win");
        }
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            float zPos = UnityEngine.Random.Range(-zRange, zRange);
            Vector3 pos = new Vector3(0, 20.0f, zPos);
            Instantiate(spawner, pos, spawner.transform.rotation);
            if (isGameOver)
            {
                StopCoroutine(SpawnTarget());
                break;
            }
        }
    }

    public void OnClickingRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    private void WinText(string message)
    {
        winLoseText.text = message;
        winLoseTextHighlight.text = message;
    }

    private void LoseText(string message)
    {
        winLoseText.text = message;
        winLoseTextHighlight.text = message;
    }

    void Paused()
    {
        if (!isPaused)
        {
            isPaused = true;
            pauseButton.SetActive(false);
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            pauseButton.SetActive(true);
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

}

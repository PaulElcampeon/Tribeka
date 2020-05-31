using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameWon { get; set; }

    public bool gameOver { get; set; }

    public int difficulty { get; set; }

    public static GameManager instance;

    private void Awake()
    {
        difficulty = 1;

        instance = this;

        DontDestroyOnLoad(this);
    }

    public void SetDifficulty(int level)
    {
        difficulty = level;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

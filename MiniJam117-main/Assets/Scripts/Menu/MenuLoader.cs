using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    public static bool GameIsPaused;
    [SerializeField]
    private GameObject _pauseMenu;
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;

        if (SceneManager.GetSceneByName("StartingScreen").isLoaded)
            return;

        if (GameIsPaused)
            Resume();
        else
            Pause();
    }

    private void Pause()
    {
        Time.timeScale = 0;
        _pauseMenu?.SetActive(true);
        GameIsPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        _pauseMenu?.SetActive(false);
        GameIsPaused = false;
    }
}

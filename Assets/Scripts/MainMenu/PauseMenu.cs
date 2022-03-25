using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SoundManager.PlaySound("pause");
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void GoMainMenu()
    {
        StartCoroutine(ActivateSound());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator ActivateSound()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Image black;
    public Animator anim;

    private void Start()
    {
        SoundManager.PlaySound("lose");
    }

    public void RestartGame()
    {
        StartCoroutine(FadingRestart());
        
    }

    public void MainMenu()
    {
        StartCoroutine(Fading());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(0);
    }

    IEnumerator FadingRestart()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(8);
    }
}

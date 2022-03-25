using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerNarrate : MonoBehaviour
{
    public Narrator narrator;

    public Image black;
    public Animator anim;

    private bool triggered = false;

    private void Start()
    {
        FindObjectOfType<NarrateManager>().StartNarrate(narrator);
    }

    private void Update()
    {
        if (!triggered)
        {
            if (NarrateManager.Instance.narrateFlag)
            {
                StartCoroutine(Fading());
                triggered = true;
            }
        }
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

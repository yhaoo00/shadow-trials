using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RemoveEnemy : MonoBehaviour
{
    public GameObject enemyHider;
    public GameObject enemySeeker;

    public Dialogue dialogue;
    private bool startDialogue = false;

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (Timer.Instance.secondsLeft == 0 && startDialogue == false)
            {
                enemySeeker.SetActive(false);
                startDialogue = true;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
    }
}

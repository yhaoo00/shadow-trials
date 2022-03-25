using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSeeker : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("hider got caught. seeker win.");
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            DialogueManager.Instance.flagController = true;
        }
    }

    private void Update()
    {
        if (DialogueManager.Instance.dialogueFlag)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if (DoorTriggerButton.Instance.gameStart)
        {
            if (Timer.Instance.secondsLeft == 0)
            {
                Debug.Log("Time out, enemy hider win.");
                SceneManager.LoadScene(23);
            }
        }
    }
}

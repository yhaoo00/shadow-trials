using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHider : MonoBehaviour
{
    public Dialogue dialogue;

    private bool end = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            Debug.Log("hider got caught.");
            SceneManager.LoadScene(23);
        }
    }

    private void Update()
    {
        Debug.Log(DoorTriggerButton.Instance.gameStart);
        if (DoorTriggerButton.Instance.gameStart)
        {
            //Debug.Log("This line is called (gameStart)");
            Debug.Log("Time left: " + Timer.Instance.secondsLeft);
            if (Timer.Instance.secondsLeft == 0)
            {
                //Debug.Log("This line is called (time end)");
                Debug.Log("Time out, hider win.");
                
                if (!end)
                {
                    //Debug.Log("This line is called (conversation)");
                    StartConv();
                    end = true;
                    DialogueManager.Instance.flagController = true;
                }

                if (DialogueManager.Instance.dialogueFlag)
                {
                    //Debug.Log("This line is called (dialogueFlag)");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }

    private void StartConv()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }    
}

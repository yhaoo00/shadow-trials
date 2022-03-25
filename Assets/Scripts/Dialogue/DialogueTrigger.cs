using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    bool isTriggered = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isTriggered)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            isTriggered = false;
        }   
    }
}

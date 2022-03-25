using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguoProc : MonoBehaviour
{
    public Dialogue dialogue;

    // Start is called before the first frame update
    void Awake()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

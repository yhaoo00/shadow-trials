using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogNoTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void Update()
    {
        if (DialogueManager.Instance.dialogueFlag)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

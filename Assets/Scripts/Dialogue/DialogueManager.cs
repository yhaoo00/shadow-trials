using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    
    public readonly Queue<string> sentences = new Queue<string>();

    public bool dialogueFlag;
    public bool flagController = false;

    public TextMeshProUGUI nameTmp;
    public TextMeshProUGUI dialogueTmp;
    public Animator anim;

    private void Start()
    {
        Instance = this;
        dialogueFlag = false;
        flagController = false;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0;
        anim.SetBool("isOpen", true);
        nameTmp.SetText(dialogue.name.ToString());

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //dialogueTmp.SetText(sentence.ToString());
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueTmp.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueTmp.text += letter;
            yield return new WaitForSecondsRealtime(.01f);
        }
    }

    void EndDialogue()
    {
        anim.SetBool("isOpen", false);
        Time.timeScale = 1;
        dialogueFlag = true;
    }

    void Update()
    {
        if ((SceneManager.GetActiveScene().buildIndex == 9) || (SceneManager.GetActiveScene().buildIndex == 12) || (SceneManager.GetActiveScene().buildIndex == 15) || (SceneManager.GetActiveScene().buildIndex == 18) || (SceneManager.GetActiveScene().buildIndex == 19))
        {
            if (Input.GetKeyDown(KeyCode.Return) && flagController)
            {
                SoundManager.PlaySound("enter");
                DisplayNextSentence();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SoundManager.PlaySound("enter");
                DisplayNextSentence();
            }
        }
    }
}

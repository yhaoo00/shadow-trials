using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NarrateManager : MonoBehaviour
{
    public static NarrateManager Instance;

    public readonly Queue<string> sentences = new Queue<string>();

    public bool narrateFlag;
    public TextMeshProUGUI dialogueTmp;

    private void Start()
    {
        Instance = this;
        narrateFlag = false;
    }

    public void StartNarrate(Narrator dialogue)
    {
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

    IEnumerator TypeSentence(string sentence)
    {
        dialogueTmp.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueTmp.text += letter;
            yield return new WaitForSecondsRealtime(.03f);
        }
    }

    void EndDialogue()
    {
        narrateFlag = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SoundManager.PlaySound("enter");
            DisplayNextSentence();
        }
    }
}

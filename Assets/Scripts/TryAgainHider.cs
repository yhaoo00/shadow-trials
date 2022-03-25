using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainHider : MonoBehaviour
{
    public Dialogue dialogue;

    public Transform enemySpawnPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            gameObject.transform.position = enemySpawnPosition.position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeekerCollide : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject enemyObject;

    public static PlayerSeekerCollide Instance;
    public bool collided;

    private void Start()
    {
        Instance = this;
        collided = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyObject.SetActive(false);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            collided = true;
        }
    }
}

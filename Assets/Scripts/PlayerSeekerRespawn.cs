using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSeekerRespawn : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public Transform playerSpawnPoint;
    public Transform enemySpawnPoint;
    public Dialogue dialogue;

    // Update is called once per frame
    void Update()
    {
        if (Timer.Instance.secondsLeft == 0 && PlayerSeekerCollide.Instance.collided == false)
        {
            player.transform.position = playerSpawnPoint.position;
            enemy.transform.position = enemySpawnPoint.position;
            PlayerMovement.Instance.fieldOfView.SetOrigin(playerSpawnPoint.position);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

            if (SceneManager.GetActiveScene().buildIndex == 5)
                Timer.Instance.secondsLeft = 35;
            if (SceneManager.GetActiveScene().buildIndex == 6)
                Timer.Instance.secondsLeft = 30;
        }
    }
}

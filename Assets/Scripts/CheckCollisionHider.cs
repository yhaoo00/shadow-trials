using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCollisionHider : MonoBehaviour
{
    private bool playSound = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 6)
            {
                if (!playSound)
                {
                    SoundManager.PlaySound("dooropen");
                    playSound = true;
                }
                DoorTriggerButton.Instance.door.OpenDoor();
                Timer.Instance.secondsLeft = 1;
                EnemyHide.Instance.speed = 0;
            }
        }
    }
}

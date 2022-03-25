using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHiderRespawn : MonoBehaviour
{
    public Transform playerSpawnPoint;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                Timer.Instance.secondsLeft = 10;
                gameObject.transform.position = playerSpawnPoint.position;
                PlayerMovement.Instance.fieldOfView.SetOrigin(playerSpawnPoint.position);
            }

            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                Timer.Instance.secondsLeft = 30;
                gameObject.transform.position = playerSpawnPoint.position;
                PlayerMovement.Instance.fieldOfView.SetOrigin(playerSpawnPoint.position);
            }
        }
    }
}

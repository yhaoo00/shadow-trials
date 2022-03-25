using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallTrigger : MonoBehaviour
{
    public GameObject InvisibleWallEntrance;
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && triggered == false)
        {
            InvisibleWallEntrance.gameObject.SetActive(true);
            triggered = true;

            if (SceneManager.GetActiveScene().buildIndex == 4)
                Timer.Instance.secondsLeft = 30;
        }
    }
}

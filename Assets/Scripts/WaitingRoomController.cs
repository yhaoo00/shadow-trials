using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitingRoomController : MonoBehaviour
{
    private void Update()
    {
        if (Timer.Instance.secondsLeft == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

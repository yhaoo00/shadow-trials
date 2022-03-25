using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public GameObject playerTypeHider;
    public GameObject playerTypeSeeker;
    public GameObject enemyTypeSeeker;
    public GameObject enemyTypeHider;

    public enum PlayMode
    {
        Hider,
        Seeker,
    }

    public PlayMode playMode;

    public PlayMode GetPlayMode()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4)
            return PlayMode.Hider;
        else if (SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 6)
            return PlayMode.Seeker;

        if (PlayAsHider.Instance.playMode == PlayMode.Hider)
            return PlayMode.Hider;
        else
            return PlayMode.Seeker;
    }

    private void Awake()
    {
        Instance = this;
        playMode = GetPlayMode();

        if (playMode == PlayMode.Hider)
        {
            playerTypeHider.SetActive(true);
            enemyTypeSeeker.SetActive(true);
        }
        else
        {
            playerTypeSeeker.SetActive(true);
            enemyTypeHider.SetActive(true);
        }
            
    }
}

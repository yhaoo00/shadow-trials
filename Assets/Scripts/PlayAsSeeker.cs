using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAsSeeker : MonoBehaviour
{
    public static PlayAsSeeker Instance;

    public Player.PlayMode playMode;

    private void Start()
    {
        Instance = this;
    }

    public void SetSeeker()
    {
        playMode = Player.PlayMode.Seeker;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
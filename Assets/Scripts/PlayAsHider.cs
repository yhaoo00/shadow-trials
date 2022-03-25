using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAsHider : MonoBehaviour
{
    public static PlayAsHider Instance;
    
    public Player.PlayMode playMode = Player.PlayMode.Seeker;

    private void Start()
    {
        Instance = this;
    }

    public void SetHider()
    {
        playMode = Player.PlayMode.Hider;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

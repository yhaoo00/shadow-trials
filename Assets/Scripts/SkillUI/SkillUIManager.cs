using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUIManager : MonoBehaviour
{
    private Player.PlayMode playMode;
    
    public GameObject ability1Hider;
    public GameObject ability2Hider;

    public GameObject ability1Seeker;
    public GameObject ability2Seeker;

    private void Start()
    {
        playMode = Player.Instance.GetPlayMode();
    }

    // Update is called once per frame
    void Update()
    {
        switch(playMode)
        {
            default:
            case Player.PlayMode.Hider:
                ability1Hider.gameObject.SetActive(true);
                ability2Hider.gameObject.SetActive(true);
                break;
            case Player.PlayMode.Seeker:
                ability1Seeker.gameObject.SetActive(true);
                ability2Seeker.gameObject.SetActive(true);
                break;
        }
    }
}

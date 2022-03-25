using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueController : MonoBehaviour
{
    public GameObject HiderDialogue;
    public GameObject SeekerDialogue;

    void Update()
    {
        if (Player.Instance.GetPlayMode() == Player.PlayMode.Hider)
            HiderDialogue.SetActive(true);
        else
            SeekerDialogue.SetActive(true);
    }
}

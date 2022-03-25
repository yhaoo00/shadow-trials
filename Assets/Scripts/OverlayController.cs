using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayController : MonoBehaviour
{
    [SerializeField] private GameObject overlay;

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.Instance.dialogueFlag)
        {
            overlay.SetActive(false);
        }
    }
}

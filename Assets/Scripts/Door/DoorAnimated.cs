using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimated : MonoBehaviour
{
    private Animator anim;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        anim.SetBool("Open", true);
    }   
    
    public void CloseDoor()
    {
        anim.SetBool("Open", false);
    }
}

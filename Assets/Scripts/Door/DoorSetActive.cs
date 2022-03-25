using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSetActive : MonoBehaviour
{
    public GameObject doorClose;
    public GameObject doorOpen;
    
    public void OpenDoor()
    {
        doorClose.gameObject.SetActive(false);
        doorOpen.gameObject.SetActive(true);
    }

    public void CloseDoor()
    {
        doorClose.gameObject.SetActive(true);
        doorOpen.gameObject.SetActive(false);
    }


}

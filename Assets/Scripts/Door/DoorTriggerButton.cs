using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTriggerButton : MonoBehaviour
{  
    public DoorSetActive door;
    public static DoorTriggerButton Instance;

    private bool triggered = false;
    private bool activated = false;
    public bool gameStart = false;

    private bool playSound = false;
    private bool playSoundClose = false;

    private void Start()
    {
        Instance = this;
        //StartCoroutine(OpenDoorCoroutine());
        triggered = false;
        activated = false;
        gameStart = false;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (Timer.Instance.secondsLeft == 0 && activated == false)
            { 
                if (!playSound)
                {
                    SoundManager.PlaySound("dooropen");
                    playSound = true;
                }
                door.OpenDoor();
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 9 || SceneManager.GetActiveScene().buildIndex == 12 || SceneManager.GetActiveScene().buildIndex == 15 || SceneManager.GetActiveScene().buildIndex == 18 || SceneManager.GetActiveScene().buildIndex == 19)
        {
            if (Timer.Instance.secondsLeft == 0 && activated == false)
            {
                if (!playSound)
                {
                    SoundManager.PlaySound("dooropen");
                    playSound = true;
                }
                door.OpenDoor();
            }
        }

        if (triggered)
        {
            triggered = false;
            if (!playSoundClose)
            {
                SoundManager.PlaySound("doorclose");
                playSoundClose = true;
            }
            door.CloseDoor();
            if (SceneManager.GetActiveScene().buildIndex == 3)
                Timer.Instance.secondsLeft = 0;
            else if (SceneManager.GetActiveScene().buildIndex == 4)
                Timer.Instance.secondsLeft = 0;
            else if (SceneManager.GetActiveScene().buildIndex == 5)
                Timer.Instance.secondsLeft = 0;
            else if (SceneManager.GetActiveScene().buildIndex == 6)
                Timer.Instance.secondsLeft = 0;
            else
            {
                Debug.Log("called");
                gameStart = true;
                Timer.Instance.secondsLeft = 90;
            }
        }
    }

    /*IEnumerator OpenDoorCoroutine()
    { 
        yield return new WaitForSeconds(waitTime);

        door.OpenDoor();

        if (SceneManager.GetActiveScene().buildIndex == 0)
            EnemyPathFinding.Instance.speed = 0;
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && activated == false)
        {
            triggered = true;
            activated = true;
            //Debug.Log("Door close");
        }
    }

}

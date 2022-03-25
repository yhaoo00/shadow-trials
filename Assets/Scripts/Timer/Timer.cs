using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    public TextMeshProUGUI textDisplay;

    private int minutesLeft = 0;
    public int secondsLeft;
    public bool takingAway = false;
    private bool isFirst = true;

    private bool playSound = false;

    private Animator anim;
    private Player.PlayMode playMode;

    private void Start()
    {
        Instance = this;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            secondsLeft = 10;
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            secondsLeft = 30;
        }

        anim = GetComponent<Animator>();
        playMode = Player.Instance.GetPlayMode();

        if (secondsLeft < 10)
            textDisplay.GetComponent<TextMeshProUGUI>().text = "0" + minutesLeft + ":" + "0" + secondsLeft;
        else
            textDisplay.GetComponent<TextMeshProUGUI>().text = "0" + minutesLeft + ":" + secondsLeft;
    }

    private void Update()
    {
        if (secondsLeft > 60)
        {
            minutesLeft = 1;
            isFirst = false;
        }

        if (secondsLeft < 30 && isFirst == false)
        {
            if (!playSound)
            {
                SoundManager.PlaySound("30seconds");
                playSound = true;
            }
            anim.SetBool("isTime", true);
            switch (playMode)
            {
                default:
                case Player.PlayMode.Hider:
                    PlayerMovement.Instance.viewDistance = 7f;
                    EnemyPathFinding.Instance.viewDistance = 10f;
                    break;
                case Player.PlayMode.Seeker:
                    PlayerMovement.Instance.moveSpeed = 7f;
                    EnemyHide.Instance.viewDistance = 15f;
                    break;
            }
        }

        //Debug.Log(minutesLeft);
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(CountDown());
        }
    }

    IEnumerator CountDown()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;

       if (secondsLeft < 60)
        {
            minutesLeft = 0;
            textDisplay.GetComponent<TextMeshProUGUI>().text = "0" + minutesLeft + ":" + secondsLeft;
        }

       if (secondsLeft >= 60)
        {
            textDisplay.GetComponent<TextMeshProUGUI>().text = "0" + minutesLeft + ":" + (secondsLeft - 60);

            if ((secondsLeft - 60) < 10)
                textDisplay.GetComponent<TextMeshProUGUI>().text = "0" + minutesLeft + ":0" + (secondsLeft - 60);
        }

        if (secondsLeft < 10)
            textDisplay.GetComponent<TextMeshProUGUI>().text = "0" + minutesLeft + ":" + "0" + secondsLeft;

        takingAway = false;
    }
}

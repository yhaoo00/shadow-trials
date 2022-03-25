using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip haste, bind, slow, truesight, lose, thirtyseconds, dooropen, click, pause, doorclose, enter;
    static AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        haste = Resources.Load<AudioClip>("haste");
        bind = Resources.Load<AudioClip>("bind");
        slow = Resources.Load<AudioClip>("slow");
        truesight = Resources.Load<AudioClip>("truesight");
        lose = Resources.Load<AudioClip>("lose");
        thirtyseconds = Resources.Load<AudioClip>("30seconds");
        dooropen = Resources.Load<AudioClip>("dooropen");
        click = Resources.Load<AudioClip>("onclick");
        pause = Resources.Load<AudioClip>("pause");
        doorclose = Resources.Load<AudioClip>("doorclose");
        enter = Resources.Load<AudioClip>("enter");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "haste":
                audioSource.PlayOneShot(haste);
                break;
            case "bind":
                audioSource.PlayOneShot(bind);
                break;
            case "slow":
                audioSource.PlayOneShot(slow);
                break;
            case "truesight":
                audioSource.PlayOneShot(truesight);
                break;
            case "lose":
                audioSource.PlayOneShot(lose);
                break;
            case "30seconds":
                audioSource.clip = thirtyseconds;
                audioSource.loop = true;
                audioSource.Play();
                break;
            case "dooropen":
                audioSource.PlayOneShot(dooropen);
                break;
            case "click":
                audioSource.PlayOneShot(click);
                break;
            case "pause":
                audioSource.PlayOneShot(pause);
                break;
            case "doorclose":
                audioSource.PlayOneShot(doorclose);
                break;
            case "enter":
                audioSource.PlayOneShot(enter);
                break;
        }
    }
}

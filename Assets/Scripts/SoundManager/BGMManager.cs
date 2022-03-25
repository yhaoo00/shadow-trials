using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public Sound[] sounds;

    public static BGMManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 20 || SceneManager.GetActiveScene().buildIndex == 22)
            Destroy(GameObject.Find("BGMManager"));

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }

    void Start()
    {
        Play("InGameBGM");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}

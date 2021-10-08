using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public Sound[] sounds;

    public static AudioManager instance;
    private BackgroundSoundManager bgSoundMgr;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        bgSoundMgr = FindObjectOfType<BackgroundSoundManager>();


        if (instance ==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            return;
        }
        sound.source.Play();
    }

    public void PlayBGSound(bool maybe)
    {
        bgSoundMgr.PlaySound(maybe);
    }
}

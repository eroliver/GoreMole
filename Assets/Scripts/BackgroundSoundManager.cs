using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundManager : MonoBehaviour
{
    
    [SerializeField]
    private float timeBetweenSounds;
    [SerializeField]
    public bool playing = false;
    private AudioManager audioManager;
    private List<string> bgSounds;
    private string soundToPlay;

    // Start is called before the first frame update
    void Start()
    {
        bgSounds = new List<string>()
        {
            "banjoOutaTune",
            "yeeYee",
            "hoooey",
            "youSuck",
            "overHere",
            "laugh1",
            "laugh2"
        };
        audioManager = GetComponent<AudioManager>();
        StartCoroutine(CycleSounds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator CycleSounds()
    {
        while (playing)
        {
            soundToPlay = bgSounds[Random.Range(0, bgSounds.Count)];
            audioManager.Play(soundToPlay);
            timeBetweenSounds = Random.Range(0.0f, 2.2f);
            yield return new WaitForSeconds(timeBetweenSounds);
        }
        
    }

    public void PlaySound(bool maybe)
    {
        playing = maybe;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundManager : MonoBehaviour
{
    
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
            "yeeYee",
            "hoooey",
            "youSuck",
            "overHere",
            "laugh1",
            "laugh2"
        };
        audioManager = GetComponent<AudioManager>();
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
            Debug.Log("called from " + gameObject);
            timeBetweenSounds = Random.Range(3f, 7f);
            yield return new WaitForSeconds(timeBetweenSounds);
        }
        
    }

    public void PlaySound(bool maybe)
    {
        playing = maybe;
        if (playing)
        {
            StartCoroutine(CycleSounds());

        }
        else
        {
            StopCoroutine(CycleSounds());
        }

    }
}

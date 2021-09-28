using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundManager : MonoBehaviour
{
    [SerializeField]
    private string[] backgroundSounds;
    [SerializeField]
    private float timeBetweenSounds;

    public static bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
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
            timeBetweenSounds = Random.Range(0.0f, 2.2f);
            yield return new WaitForSeconds(timeBetweenSounds);
        }
        
    }
}

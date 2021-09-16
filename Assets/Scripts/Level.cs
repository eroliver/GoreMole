using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    List<Vector3> moleHoles;
    [SerializeField]
    private Mole molePrefab;

    private bool spawning;

    // Start is called before the first frame update
    void Start()
    {
        spawning = true;
        moleHoles = new List<Vector3>()
        {
            new Vector3(-7, -1, 4.25f),
            new Vector3(0, -1, 4.25f),
            new Vector3(7, -1, 4.25f),
            new Vector3(-3.5f, -1, -2),
            new Vector3(3.5f, -1, -2)
        };

        StartCoroutine("SpawnMoles");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMoles()
    {
        while (spawning)
        {
            int molePosition = Random.Range(0, 5);
            Instantiate(molePrefab, moleHoles[molePosition], transform.rotation);
            yield return new WaitForSeconds(3f);
        }
    }

    
}

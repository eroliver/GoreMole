using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    

    [SerializeField]
    List<Vector3> moleHoles;
    [SerializeField]
    private List<Mole> molePrefabs;

    private float spawnRate;
    private int moleSelection;

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
    IEnumerator SpawnMoles()
    {
        while (spawning)
        {
            spawnRate = Random.Range(0.0f, 2.2f);
            //make ranges based on size of the lists, or tied to variable deciding difficulty
            int molePosition = Random.Range(0, 5);
            int moleSelection = Random.Range(0, molePrefabs.Count);
            Instantiate(molePrefabs[moleSelection], moleHoles[molePosition], transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
    }

}

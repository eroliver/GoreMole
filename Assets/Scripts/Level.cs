using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    
    List<Vector3> moleHoles;
    [SerializeField]
    private List<Mole> molePrefabs;
    [SerializeField]
    private float minRate;
    [SerializeField]
    private float maxRate;
    private float spawnRate;
    private int moleSelection;
    [SerializeField]
    private bool spawning;
    private float spawnCheckRadius;

    // Start is called before the first frame update
    void Start()
    {
        spawnCheckRadius = 0.2f;

        moleHoles = new List<Vector3>()
        {
            //new Vector3(-7, -1, 4.25f),
            //new Vector3(0, -1, 4.25f),
            //new Vector3(7, -1, 4.25f),
            //new Vector3(-3.5f, -1, -2),
            //new Vector3(3.5f, -1, -2)
        };

        ListHoles();

        spawning = true;


        StartCoroutine("SpawnMoles");
    }

    IEnumerator SpawnMoles()
    {
        while (spawning)
        {
            spawnRate = Random.Range(minRate, maxRate);
            //make ranges based on size of the lists, or tied to variable deciding difficulty
            int molePosition = Random.Range(0, moleHoles.Count);
            int moleSelection = Random.Range(0, molePrefabs.Count);
            if (!Physics.CheckSphere(moleHoles[molePosition], spawnCheckRadius))
            {
                Instantiate(molePrefabs[moleSelection], moleHoles[molePosition], transform.rotation);
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void ListHoles()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Hole")
            {
                moleHoles.Add(child.position);
            }
        }
    }


}

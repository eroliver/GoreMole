using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField]
    private float moleSpeed;
    [SerializeField]
    private List<GameObject> droppableParts;
    [SerializeField]
    private ParticleLauncher goreLauncher;
    [SerializeField]
    private GameObject moleMesh;

    private Vector3 droppableSpeed;
    private Transform molePosition;
    private Vector3 startPosition;
    private Vector3 molePop;
    private bool popped;
    [SerializeField]
    private int points;

    public delegate void HitAction(int points);
    public static event HitAction OnHit;

    void Start()
    {
        
        molePosition = this.transform;
        startPosition = gameObject.GetComponentInParent<Transform>().position;
        molePop = new Vector3(molePosition.position.x, (molePosition.position.y + 3), molePosition.position.z);
        popped = false;
    }

    void Update()
    {
        PopUp();
    }

    public void Hit()
    {
        for (int i = 0; i < droppableParts.Count; i++)
        {
            droppableSpeed = new Vector3(Random.Range(-30, 30), Random.Range(-30, 30), Random.Range(-30, 30));
            GameObject dropped = Instantiate(droppableParts[i], this.transform.position, Quaternion.identity);
            dropped.GetComponent<Rigidbody>().velocity = droppableSpeed;
        }

        //Instantiate(goreParticles, this.transform.position, Quaternion.identity);

        goreLauncher.LaunchGore();

        //gameObject.SetActive(false);
        moleMesh.SetActive(false);


        OnHit(points);
    }

    private void PopUp()
    {
        float step = moleSpeed * Time.deltaTime;
        if(!popped)
        {
            molePosition.position = Vector3.MoveTowards(molePosition.position, molePop, step);
        }
        else
        {
            molePosition.position = Vector3.MoveTowards(molePosition.position, startPosition, step);
        }

        if (molePosition.position.y > 1.5f)
        {
            popped = true;
            
        }

        if(popped && molePosition.position.y < -0.98f)
        {
            moleMesh.SetActive(false);
        }
    }
}

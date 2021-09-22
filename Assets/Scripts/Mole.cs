using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField]
    private float moleSpeed;
    [SerializeField]
    private GameObject goreParticles;

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
        molePop = new Vector3(molePosition.position.x, (molePosition.position.y + 2), molePosition.position.z);
        popped = false;
    }

    void Update()
    {
        PopUp();
    }

    public void Hit()
    {
        Instantiate(goreParticles, this.transform.position, Quaternion.identity);

        gameObject.SetActive(false);
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

        if (molePosition.position.y > 0.95f)
        {
            popped = true;
            
        }

        if(popped && molePosition.position.y < -0.98f)
        {
            Destroy(gameObject);
        }
    }
}

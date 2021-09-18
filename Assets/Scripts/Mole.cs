using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField]
    private float moleSpeed;

    private Transform molePosition;
    private Vector3 startPosition;
    //private Vector3 endPosition;
    private Vector3 molePop;
    private bool popped;
    [SerializeField]
    private int points;

    //[SerializeField]
    //[Range(0f, 1f)]
    //private float lerpPercent;

    public delegate void HitAction(int points);
    public static event HitAction OnHit;

    // Start is called before the first frame update
    void Start()
    {
        molePosition = this.transform;
        startPosition = gameObject.GetComponentInParent<Transform>().position;
        //endPosition = new Vector3(3.5f, 2, -2);
        //moleSpeed = 1.5f;
        molePop = new Vector3(molePosition.position.x, (molePosition.position.y + 2), molePosition.position.z);
        popped = false;
        //points = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //molePosition.position = Vector3.Lerp(molePosition.position, endPosition, moleSpeed * Time.deltaTime);
        //molePosition.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 2, 2 + 2) - 2, transform.position.z);
        PopUp();
    }

    public void Hit()
    {
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

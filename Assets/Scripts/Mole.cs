using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    private Transform molePosition;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float moleSpeed;

    [SerializeField]
    [Range(0f, 1f)]
    private float lerpPercent;

    // Start is called before the first frame update
    void Start()
    {
        molePosition = this.transform;
        startPosition = new Vector3(3.5f, -2, -2);
        endPosition = new Vector3(3.5f, 2, -2);
        moleSpeed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //molePosition.position = Vector3.Lerp(molePosition.position, endPosition, moleSpeed * Time.deltaTime);
        molePosition.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 2, 2 + 2) - 2, transform.position.z);

    }

    private void Hit()
    {
        gameObject.SetActive(false);
    }
}

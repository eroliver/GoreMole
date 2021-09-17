using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        if (camera == null)
        {
            camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //refector to accept the current weapon position once weapon follows the mouse.
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                hit.transform.gameObject.SendMessage("Hit", SendMessageOptions.DontRequireReceiver);
            }
        }
        
    }
}

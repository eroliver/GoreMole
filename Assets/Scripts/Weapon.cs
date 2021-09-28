using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    private RaycastHit hit;
    private Vector3 mousePosition;
    private Transform weaponTransform;
    private Animator hammerAnimator;
    private CameraShake cameraShaker;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        if (camera == null)
        {
            camera = Camera.main;
        }
        weaponTransform = transform;
        hammerAnimator = GetComponentInChildren<Animator>();
        cameraShaker = camera.GetComponent<CameraShake>();

        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f))
        {
            transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            
        }
        //refector to accept the current weapon position once weapon follows the mouse.
        if (Input.GetMouseButtonDown(0))
        {
            audioManager.Play("hammerSwing");

            if (Physics.Raycast(ray, out hit, 100f))
            {
                hammerAnimator.SetTrigger("Swing");
                hit.transform.parent.SendMessage("Hit", SendMessageOptions.DontRequireReceiver);
                cameraShaker.ShakeCamera();
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMole : MonoBehaviour
{
    [SerializeField]
    private int sceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        GameManager.gameManager.startSelectedScene(sceneNumber);
    }
}

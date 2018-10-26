using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camera : MonoBehaviour {
    public Camera mainCamera;
    public Camera TopCamera;

    void Start()
    {
        mainCamera.enabled = true;
        TopCamera.enabled = false;
    }
    void Update()
    {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    mainCamera.enabled = !mainCamera.enabled;
                    TopCamera.enabled = !TopCamera.enabled;
                }
    }

    
    
}

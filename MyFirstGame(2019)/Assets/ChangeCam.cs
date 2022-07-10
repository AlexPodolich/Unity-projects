using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    // Start is called before the first frame update
    void Start()
    {
        cam1.active = false;
        cam2.active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("1"))
        {
            cam1.active = true;
            cam2.active = false;
        }
        else if (Input.GetKeyUp("2"))
        {
            cam1.active = false;
            cam2.active = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;
    public GameObject cam6;
    public GameObject cam7;
    public GameObject cam8;
    // Start is called before the first frame update
    void Start()
    {
        cam1.active = true;
        cam2.active = false;
        cam3.active = false;
        cam4.active = false;
        cam5.active = false;
        cam6.active = false;
        cam7.active = false;
        cam8.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("1"))
        {
            cam1.active = true;
            cam2.active = false;
            cam3.active = false;
            cam4.active = false;
            cam5.active = false;
            cam6.active = false;
            cam7.active = false;
            cam8.active = false;
        }
        else if (Input.GetKeyUp("2"))
        {
            cam1.active = false;
            cam2.active = true;
            cam3.active = false;
            cam4.active = false;
            cam5.active = false;
            cam6.active = false;
            cam7.active = false;
            cam8.active = false;
        }
        else if (Input.GetKeyUp("3"))
        {
            cam1.active = false;
            cam2.active = false;
            cam3.active = true;
            cam4.active = false;
            cam5.active = false;
            cam6.active = false;
            cam7.active = false;
            cam8.active = false;
        }
        else if (Input.GetKeyUp("4"))
        {
            cam1.active = false;
            cam2.active = false;
            cam3.active = false;
            cam4.active = true;
            cam5.active = false;
            cam6.active = false;
            cam7.active = false;
            cam8.active = false;
        }
        else if (Input.GetKeyUp("5"))
        {
            cam1.active = false;
            cam2.active = false;
            cam3.active = false;
            cam4.active = false;
            cam5.active = true;
            cam6.active = false;
            cam7.active = false;
            cam8.active = false;
        }
        else if (Input.GetKeyUp("6"))
        {
            cam1.active = false;
            cam2.active = false;
            cam3.active = false;
            cam4.active = false;
            cam5.active = false;
            cam6.active = true;
            cam7.active = false;
            cam8.active = false;
        }
        else if (Input.GetKeyUp("7"))
        {
            cam1.active = false;
            cam2.active = false;
            cam3.active = false;
            cam4.active = false;
            cam5.active = false;
            cam6.active = false;
            cam7.active = true;
            cam8.active = false;
        }
        else if (Input.GetKeyUp("8"))
        {
            cam1.active = false;
            cam2.active = false;
            cam3.active = false;
            cam4.active = false;
            cam5.active = false;
            cam6.active = false;
            cam7.active = false;
            cam8.active = true;
        }

    }
}

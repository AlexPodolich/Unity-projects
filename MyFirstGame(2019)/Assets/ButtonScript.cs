using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public GameObject theNPC;

    void Start()
    {
        theNPC = (GameObject)this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            theNPC.GetComponent<Animator>().Play("Idle");
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
        {
            theNPC.GetComponent<Animator>().Play("Walk");
        }else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            theNPC.GetComponent<Animator>().Play("Run");
        }else if(Input.GetKey(KeyCode.W))
        {
            theNPC.GetComponent<Animator>().Play("Sprint");
        }

        if (Input.GetKey(KeyCode.Q))
        {
            theNPC.GetComponent<Animator>().Play("Attack1");
        }

        if (Input.GetKey(KeyCode.E))
        {
            theNPC.GetComponent<Animator>().Play("Attack2");
        }
    }
}

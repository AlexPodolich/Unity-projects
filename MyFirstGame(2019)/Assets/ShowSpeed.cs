using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowSpeed : MonoBehaviour
{
    public TMP_Text SpeedInfo;
    // Start is called before the first frame update
    void Start()
    {
        SpeedInfo = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void textUpdate(float value)
    {
        if(value < 10)
        {
            SpeedInfo.text = "0.0" + value.ToString() + "f";
        }
        if(value > 10 || value == 10)
        {
            SpeedInfo.text = "0." + value.ToString() + "f";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowValue : MonoBehaviour
{
    public TMP_Text ValueText;
    public Text ValueText1;
    // Start is called before the first frame update
    void Start()
    {
        ValueText = GetComponent<TMP_Text>();
        ValueText1 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void textUpdate(float value)
    {
        ValueText.text = value.ToString();
    }

    public void textUpdate1(float value)
    {
        ValueText1.text = value.ToString();
    }
}

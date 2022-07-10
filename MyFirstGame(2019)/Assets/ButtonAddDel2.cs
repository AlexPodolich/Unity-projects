using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ButtonAddDel2 : MonoBehaviour
{
    public ParamsSave numMonstrs;
    public int chislo = 0;
    public Text numberMonstr;
    // Start is called before the first frame update
    void Start()
    {
        numberMonstr = GameObject.Find("chisloMonstr").GetComponent<Text>();
        numMonstrs = GameObject.Find("ParamsSave").GetComponent<ParamsSave>();
    }

    // Update is called once per frame
    void Update()
    {
        //numCoins = chislo;
        chislo = int.Parse(numberMonstr.text);
    }

    public void AddPoints()
    {
        if(chislo <= 13)
        {
            chislo += 1;
            numberMonstr.text = chislo.ToString();
        }
        
    }

    public void DelPoints()
    {
        if(chislo >=5)
        {
            chislo -= 1;
            numberMonstr.text = chislo.ToString();
        }
        
    }
}

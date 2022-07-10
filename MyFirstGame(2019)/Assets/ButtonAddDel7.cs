using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ButtonAddDel7 : MonoBehaviour
{
    public ParamsSave numCoins;
    public float chislo;
    public Text numberCoin;
    // Start is called before the first frame update
    void Start()
    {
        numberCoin = GameObject.Find("monstrSpd").GetComponent<Text>();
        numCoins = GameObject.Find("ParamsSave").GetComponent<ParamsSave>();
    }

    // Update is called once per frame
    void Update()
    {
        //numCoins = chislo;
        chislo = float.Parse(numberCoin.text);
    }

    public void AddPoints()
    {
        if(chislo < 0.5f)
        {
            chislo += 0.05f;
            numberCoin.text = chislo.ToString().Replace(",",".") + "f";
            print(chislo);
        }
        if(chislo > 0.49f)
        {
            numberCoin.text = "0.5f";
            chislo = 0.5f;
            print(chislo);
        }
        if(chislo == 0.05f)
        {
            numberCoin.text = "0.1f";
            print(chislo);
        }
        if(chislo == 0.1f)
        {
            numberCoin.text = "0.15f";
            print(chislo);
        }  
    }

    public void speed1()
    {
        chislo = 0.05f;
        numberCoin.text = chislo.ToString().Replace(",",".") + "f";
        print(chislo);
    }

    public void speed2()
    {
        chislo = 0.1f;
        numberCoin.text = chislo.ToString().Replace(",",".") + "f";
        print(chislo);
    }

    public void speed3()
    {
        chislo = 0.15f;
        numberCoin.text = chislo.ToString().Replace(",",".") + "f";
        print(chislo);
    }

    public void speed4()
    {
        chislo = 0.2f;
        numberCoin.text = chislo.ToString().Replace(",",".") + "f";
        print(chislo);
    }

    public void speed5()
    {
        chislo = 0.25f;
        numberCoin.text = chislo.ToString().Replace(",",".") + "f";
        print(chislo);
    }

    public void speed6()
    {
        chislo = 0.3f;
        numberCoin.text = chislo.ToString().Replace(",",".") + "f";
        print(chislo);
    }

    public void speed7()
    {
        chislo = 0.35f;
        numberCoin.text = chislo.ToString().Replace(",",".") + "f";
        print(chislo);
    }

    public void speed8()
    {
        chislo = 0.4f;
        numberCoin.text = chislo.ToString().Replace(",",".") + "f";
        print(chislo);
    }

    public void speed9()
    {
        chislo = 0.45f;
        numberCoin.text = chislo.ToString().Replace(",",".") + "f";
        print(chislo);
    }

    public void speed10()
    {
        chislo = 0.5f;
        numberCoin.text = chislo.ToString().Replace(",",".") + "f";
        print(chislo);
    }


}

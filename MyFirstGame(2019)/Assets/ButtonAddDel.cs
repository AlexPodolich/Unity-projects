﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ButtonAddDel : MonoBehaviour
{
    public ParamsSave numCoins;
    public int chislo = 0;
    public Text numberCoin;
    // Start is called before the first frame update
    void Start()
    {
        numberCoin = GameObject.Find("chisloCoins").GetComponent<Text>();
        numCoins = GameObject.Find("ParamsSave").GetComponent<ParamsSave>();
    }

    // Update is called once per frame
    void Update()
    {
        //numCoins = chislo;
        chislo = int.Parse(numberCoin.text);
    }

    public void AddPoints()
    {
        if(chislo <= 24)
        {
            chislo += 1;
            numberCoin.text = chislo.ToString();
        }
        
    }

    public void DelPoints()
    {
        if(chislo >=6)
        {
            chislo -= 1;
            numberCoin.text = chislo.ToString();
        }
        
    }
}

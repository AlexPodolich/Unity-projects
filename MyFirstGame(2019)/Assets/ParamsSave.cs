using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ParamsSave : MonoBehaviour
{
    public int numOfCoins;
    public int numOfMonsters;
    public int heroHealthic;
    public int fireBallDamage;
    public int monsterHealth;
    public int monsterdamage;
    public string monsterSpeed;

    public Text chisloCoins;
    public Text chisloMonstr;
    public Text heroHP;
    public Text fireBallDmg;
    public Text monstrHealth;
    public Text monstrDmg;
    public Text monstrSpd;

    public void Start()
    {
        chisloCoins = GameObject.Find("chisloCoins").GetComponent<Text>();
        chisloMonstr = GameObject.Find("chisloMonstr").GetComponent<Text>();
        heroHP = GameObject.Find("heroHP").GetComponent<Text>();
        fireBallDmg = GameObject.Find("fireBallDmg").GetComponent<Text>();
        monstrHealth = GameObject.Find("monstrHealth").GetComponent<Text>();
        monstrDmg = GameObject.Find("monstrDmg").GetComponent<Text>();
        monstrSpd = GameObject.Find("monstrSpd").GetComponent<Text>();

        DontDestroyOnLoad(this.gameObject);

    }

    public void Update()
    {
        numOfCoins = int.Parse(chisloCoins.text);
        numOfMonsters = int.Parse(chisloMonstr.text);
        heroHealthic = int.Parse(heroHP.text);
        fireBallDamage = int.Parse(fireBallDmg.text);
        monsterHealth = int.Parse(monstrHealth.text);
        monsterdamage = int.Parse(monstrDmg.text);
        monsterSpeed = monstrSpd.text;
    }
}

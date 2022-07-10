using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthCounter : MonoBehaviour
{
    public TMP_Text numberHealth;
    public int heroHealth;
    public ParamsSave HeroHp;
    public int maxHealth;
    public int monstrDmg;
    void Start()
    {
        HeroHp = GameObject.Find("ParamsSave").GetComponent<ParamsSave>();
        numberHealth = GameObject.Find("HealthCounter").GetComponent<TMP_Text>();
        heroHealth = HeroHp.heroHealthic;
        numberHealth.text = "Health: " + heroHealth.ToString();
        maxHealth = HeroHp.heroHealthic;
        monstrDmg = HeroHp.monsterdamage;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("monster"))
        {
            heroHealth -= monstrDmg;
            numberHealth.text = "Health: " + heroHealth.ToString();
        }

        if (collision.gameObject.tag.Equals("FireBall"))
        {
            if(heroHealth < maxHealth)
            {
                heroHealth += 10;
                numberHealth.text = "Health: " + heroHealth.ToString();
            }

            if(heroHealth > maxHealth)
            {
                heroHealth = maxHealth;
                numberHealth.text = "Health: " + heroHealth.ToString();
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System.Security.Cryptography;
using UnityEngine.UI;
using TMPro;

public class MonsterScript : MonoBehaviour
{
    public int fireBallDmg;
    public int monsterHealth;
    public GameObject Player;
    public float TargetDistance;
    public float AllowedRange = 1;
    public GameObject monster;
    public float speed;
    public string speedInfo;
    public RaycastHit Shot;
    public ParamsSave HeroHp;

    // Start is called before the first frame update
    void Start()
    {
        monster = (GameObject)this.gameObject;
        Player = GameObject.FindWithTag("Player");
        HeroHp = GameObject.Find("ParamsSave").GetComponent<ParamsSave>();
        monsterHealth = HeroHp.monsterHealth;
        fireBallDmg = HeroHp.fireBallDamage;

        //speedInfo = GameObject.Find("monsterSpeed").GetComponent<TMP_Text>().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out Shot))
        {
            TargetDistance = Shot.distance;
            if(TargetDistance >= AllowedRange)
            {
                if(HeroHp.monsterSpeed == "0.05f")
                {
                    speed = 0.05f;
                }
                if(HeroHp.monsterSpeed == "0.1f")
                {
                    speed = 0.1f;
                }
                if(HeroHp.monsterSpeed == "0.15f")
                {
                    speed = 0.15f;
                }
                if(HeroHp.monsterSpeed == "0.2f")
                {
                    speed = 0.2f;
                }
                if(HeroHp.monsterSpeed == "0.25f")
                {
                    speed = 0.25f;
                }
                if(HeroHp.monsterSpeed == "0.3f")
                {
                    speed = 0.3f;
                }
                if(HeroHp.monsterSpeed == "0.35f")
                {
                    speed = 0.35f;
                }
                if(HeroHp.monsterSpeed == "0.4f")
                {
                    speed = 0.4f;
                }
                if(HeroHp.monsterSpeed == "0.45f")
                {
                    speed = 0.45f;
                }
                if(HeroHp.monsterSpeed == "0.5f")
                {
                    speed = 0.5f;
                }
                //print(speedInfo);
                //speed = 0.1f;
                //speed = HeroHp.monsterSpeed;
                print("speed: " + speed);
                monster.GetComponent<Animator>().Play("Run");
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed);
            }
            else
            {
                speed = 0;
                monster.GetComponent<Animator>().Play("Ready");
            }
        }

        Debug.Log(monsterHealth);

        if(monsterHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("FireBall"))
        {
            //Destroy(collision.gameObject);
            monsterHealth = monsterHealth - fireBallDmg;

        }

    }
}

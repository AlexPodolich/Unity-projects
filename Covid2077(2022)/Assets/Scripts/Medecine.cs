using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Medecine : MonoBehaviour
{
    private float timeAlive;
    private Player player; 
    private AudioScript sound;
    public GameObject bigExplosionEffect;
    void Awake(){
        sound = FindObjectOfType<AudioScript>();
        player = FindObjectOfType<Player>();
        float timePlayed = player.getTimeInGame();
        float newTimeAlive = 3f - (timePlayed/20) * 0.1f;
        if(newTimeAlive < 2f){
            newTimeAlive = 2f;
        }
        timeAlive = newTimeAlive;
    }

    void Update(){
        timeAlive -= Time.deltaTime;
        if(timeAlive <= 0 || player.getLose()){
            Destroy(gameObject);
        }
    }

    void OnMouseDown(){
        sound.onBigExplosionSound();
        Instantiate(bigExplosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        player.setLose(true);
    }
}

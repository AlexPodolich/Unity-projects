using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Corona : MonoBehaviour
{
    private float timeAlive;
    private float firstStage;
    private float secondStage;
    private float thirdStage;
    private Player player;
    private AudioScript sound;
    public GameObject killEffect;
    public GameObject explosionEffect;
    public Sprite yellowVirus;
    public Sprite redVirus;

    void Awake(){
        player = FindObjectOfType<Player>();
        float timePlayed = player.getTimeInGame();
        float newMinTimeAlive = 2f - (timePlayed/10) * 0.1f;
        float newMaxTimeAlive = 4f - (timePlayed/10) * 0.1f;
        if(newMinTimeAlive < 0.5f){
            newMinTimeAlive = 0.5f;
        }
        if(newMaxTimeAlive < 2f){
            newMaxTimeAlive = 2f;
        }
        sound = FindObjectOfType<AudioScript>();
        timeAlive = Random.Range(newMinTimeAlive, newMaxTimeAlive);
        secondStage = timeAlive*0.65f;
        thirdStage = timeAlive*0.35f;
    }


    void Update(){
        timeAlive -= Time.deltaTime;
        
        if(player.getLose() == true){
            Destroy(gameObject);
        }
        if(timeAlive <= 0){
            int newHealth = player.getHealth() - 1;
            player.setHealth(newHealth);
            Destroy(gameObject);
            sound.onExplosionSound();
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
        if(timeAlive < secondStage && timeAlive > thirdStage){
            gameObject.GetComponent<Image>().sprite = yellowVirus;
        }
        if(timeAlive < thirdStage && timeAlive > 0){
            gameObject.GetComponent<Image>().sprite = redVirus;
        }
    }
    void OnMouseDown(){
        sound.onKillSound();
        int scoreForKilling;
        switch(player.getDifficulty()){
            case "easy":
                scoreForKilling = 1;
                break;
            case "normal":
                scoreForKilling = 2;
                break;
            case "hard":
                scoreForKilling = 3;
                break;
            default:
                scoreForKilling = 1;
                break;
        }
        int newScore = player.getScore() + scoreForKilling;
        player.setScore(newScore);
        Destroy(gameObject);
        Instantiate(killEffect, transform.position, transform.rotation);
    }
}

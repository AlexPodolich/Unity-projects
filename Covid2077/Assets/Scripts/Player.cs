using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private bool lose; 
    private int score;
    private int health;
    private int bestRecord;
    private string difficulty;
    private float timeInGame;
    void Awake(){
        lose = false;
        if(PlayerPrefs.GetString("diff") == "easy" || PlayerPrefs.GetString("diff") == "normal" || PlayerPrefs.GetString("diff") == "hard"){
            difficulty = PlayerPrefs.GetString("diff");
        }else{
            difficulty = "easy";
        }

        bestRecord = PlayerPrefs.GetInt("best");

        score = 0;
        switch(difficulty){
            case "easy":
                health = 3;
                break;
            case "normal":
                health = 2;
                break;
            case "hard":
                health = 1;
                break;
        }
    }

    void Update(){
        if(!lose){
            timeInGame += Time.deltaTime;
        }
    }

    public bool getLose(){
        return lose;
    }

    public void setLose(bool lose){
        this.lose = lose;
    }

    public int getScore(){
        return score;
    }

    public void setScore(int score){
        this.score = score;
    }

    public int getHealth(){
        return health;
    }

    public void setHealth(int health){
        this.health = health;
    }

    public int getBestRecord(){
        return bestRecord;
    }

    public void setBestRecord(int bestRecord){
        this.bestRecord = bestRecord;
    }

    public string getDifficulty(){
        return difficulty;
    }

    public void setDifficulty(string difficulty){
        this.difficulty = difficulty;
    }

    public float getTimeInGame(){
        return timeInGame;
    }

    public void setTimeInGame(float timeInGame){
        this.timeInGame = timeInGame;
    }

    
    
}

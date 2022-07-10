using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public Text bestRecord;
    private BtnClick sound;
    private float timer;
    private bool btnClicked;
    private string clickedBtnName;
    void Awake(){
        sound = FindObjectOfType<BtnClick>();
        timer = 0.15f;
        bestRecord.text = PlayerPrefs.GetInt("best").ToString();
    }

    void Update(){
        if(btnClicked){
        timer -= Time.deltaTime;
            if(timer <= 0){
                switch(clickedBtnName){
                    case "diffBtn":
                        SceneManager.LoadScene("SelectDifficulty");
                        break;
                    case "exit":
                        Application.Quit();
                        break;
                    case "start":
                        SceneManager.LoadScene("GameScene");
                        break;
                }
            }
        }
    }

    public void selectDiffBtn()
    {
        sound.btnClicked();
        btnClicked = true;
        clickedBtnName = "diffBtn";
    }

    public void exit(){
        sound.btnClicked();
        btnClicked = true;
        clickedBtnName = "exit";
    }

    public void startGame()
    {
        sound.btnClicked();
        btnClicked = true;
        clickedBtnName = "start";
    }

}

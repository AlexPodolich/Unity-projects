using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectDiffSceneScript : MonoBehaviour
{
    private Player player;
    private BtnClick sound;
    public Image difficultyText;
    public Sprite easyDiffSprite;
    public Sprite normalDiffSprite;
    public Sprite hardDiffSprite;
    public Button btnEasy;
    public Button btnNormal;
    public Button btnHard;
    public Sprite btnEasyPressed;
    public Sprite btnNormalPressed;
    public Sprite btnHardPressed;
    public Sprite btnEasyUnpressed;
    public Sprite btnNormalUnpressed;
    public Sprite btnHardUnpressed;
    private float timer;
    private bool isMenuBtnClicked;
    void Awake(){
        player = FindObjectOfType<Player>();
        sound = FindObjectOfType<BtnClick>();
        timer = 0.15f;
        isMenuBtnClicked = false;
    }

    void Start(){
        switch(player.getDifficulty()){
            case "easy":
                btnEasy.GetComponent<Image>().sprite = btnEasyPressed;
                break;
            case "normal":
                btnNormal.GetComponent<Image>().sprite = btnNormalPressed;
                break;
            case "hard":
                btnHard.GetComponent<Image>().sprite = btnHardPressed;
                break;
        }
    }

    void Update()
    {
        if(isMenuBtnClicked){
            timer -= Time.deltaTime;
            if(timer <= 0){
                SceneManager.LoadScene("MenuScene");    
            }   
        }
        switch(player.getDifficulty()){
            case "easy":
                difficultyText.sprite = easyDiffSprite;
                btnEasy.GetComponent<Image>().sprite = btnEasyPressed;
                break;
            case "normal":
                difficultyText.sprite = normalDiffSprite;
                btnNormal.GetComponent<Image>().sprite = btnNormalPressed;
                break;
            case "hard":
                difficultyText.sprite = hardDiffSprite;
                btnHard.GetComponent<Image>().sprite = btnHardPressed;
                break;
        }
        PlayerPrefs.SetString("diff", player.getDifficulty());
    }

    public void clickOnEasyBtn(){
        sound.btnClicked();
        player.setDifficulty("easy");
        btnEasy.gameObject.GetComponent<Image>().sprite = btnEasyPressed;
        btnNormal.gameObject.GetComponent<Image>().sprite = btnNormalUnpressed;
        btnHard.gameObject.GetComponent<Image>().sprite = btnHardUnpressed;
    }

    public void clickOnNormalBtn(){
        sound.btnClicked();
        player.setDifficulty("normal");
        btnEasy.gameObject.GetComponent<Image>().sprite = btnEasyUnpressed;
        btnNormal.gameObject.GetComponent<Image>().sprite = btnNormalPressed;
        btnHard.gameObject.GetComponent<Image>().sprite = btnHardUnpressed;
    }

    public void clickOnHardBtn(){
        sound.btnClicked();
        player.setDifficulty("hard");
        btnEasy.gameObject.GetComponent<Image>().sprite = btnEasyUnpressed;
        btnNormal.gameObject.GetComponent<Image>().sprite = btnNormalUnpressed;
        btnHard.gameObject.GetComponent<Image>().sprite = btnHardPressed;
    }

    public void backToMenuBtn()
    {
        sound.btnClicked();
        isMenuBtnClicked = true;
    }
}

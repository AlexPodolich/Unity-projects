using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameSceneScript : MonoBehaviour
{
    private Player player;
    private BtnClick sound;
    public Canvas gameCanvas;
    public GameObject gameOverCanvas;
    public GameObject infoBar;
    public Canvas playingZone;
    public Image difficultyInfoBar;
    public Text finalScoreGameOver;
    public Text playedTimeSecGameOver;
    public Text playedTimeMinGameOver;
    public Text bestRecordGameOver;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Sprite heart;
    public Sprite deadHeart;
    public Text scoreBarInfoBar;
    public Text secTxtInfoBar;
    public Text minTxtInfoBar;
    public Sprite easyDiffSprite;
    public Sprite normalDiffSprite;
    public Sprite hardDiffSprite;
    private bool isMenuBtnClicked;
    private float timer;
    
    void Awake()
    {
        gameOverCanvas.SetActive(false);
        infoBar.SetActive(true);
        timer = 0.15f;
        isMenuBtnClicked = false;
        Destroy(GameObject.FindGameObjectWithTag("GameMusic"));
        player = FindObjectOfType<Player>();
    }

    void Start(){
        float newHeight = (float)(gameCanvas.GetComponent<RectTransform>().rect.height - infoBar.GetComponent<RectTransform>().rect.height);
        playingZone.GetComponent<RectTransform>().sizeDelta = new Vector2(0, newHeight);
        switch(player.getDifficulty()){
            case "easy":
                difficultyInfoBar.sprite = easyDiffSprite;
                break;
            case "normal":
                difficultyInfoBar.sprite = normalDiffSprite;
                break;
            case "hard":
                difficultyInfoBar.sprite = hardDiffSprite;
                break;
        }
    }

    void Update(){
        if(player.getLose()==true){
            gameOver();
        }
        int secInGame = (int)player.getTimeInGame();
        int minInGame = secInGame/60;
        secInGame -= minInGame*60;
        secTxtInfoBar.text = secInGame.ToString();
        minTxtInfoBar.text = minInGame.ToString();
        scoreBarInfoBar.text = player.getScore().ToString();
        switch(player.getHealth()){
            case 3:
                heart1.sprite = heart;
                heart2.sprite = heart;
                heart3.sprite = heart;
                break;
            case 2:
                heart1.sprite = heart;
                heart2.sprite = heart;
                heart3.sprite = deadHeart;
                break;
            case 1:
                heart1.sprite = heart;
                heart2.sprite = deadHeart;
                heart3.sprite = deadHeart;
                break;
            case 0:
                heart1.sprite = deadHeart;
                heart2.sprite = deadHeart;
                heart3.sprite = deadHeart;
                player.setLose(true);
                break;
        }
        if(isMenuBtnClicked){
            timer -= Time.deltaTime;
            if(timer <= 0){
                SceneManager.LoadScene("MenuScene");    
            }   
        }
    }
    
    void gameOver()
    {
        gameOverCanvas.SetActive(true);
        int secInGame = (int)player.getTimeInGame();
        int minInGame = secInGame/60;
        secInGame -= minInGame*60;
        playedTimeSecGameOver.text = secInGame.ToString();
        playedTimeMinGameOver.text = minInGame.ToString();
        if(player.getScore() > player.getBestRecord()){
            PlayerPrefs.SetInt("best", player.getScore());
        }
        if(PlayerPrefs.GetInt("best") > player.getScore()){
            bestRecordGameOver.text = PlayerPrefs.GetInt("best").ToString();
        }else{
            bestRecordGameOver.text = player.getScore().ToString();
        }
        
        finalScoreGameOver.text = player.getScore().ToString();
        infoBar.SetActive(false);
        sound = FindObjectOfType<BtnClick>();
    }

    public void backToMenuBtn()
    {
        sound.btnClicked();
        isMenuBtnClicked = true;
    }

}

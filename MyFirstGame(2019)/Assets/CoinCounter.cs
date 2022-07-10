using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinCounter : MonoBehaviour
{
    public TMP_Text numberCoin;
    public int coins = 0;
    public int currentCoins;
    public SpawnCoins numCoins;
    public ParamsSave SaveParams;
    public int coinsMax;
    // Start is called before the first frame update
    void Start()
    {
        numberCoin = GameObject.Find("CoinCounter").GetComponent<TMP_Text>();
        numCoins = GameObject.Find("Terrain").GetComponent<SpawnCoins>();
        SaveParams = GameObject.Find("ParamsSave").GetComponent<ParamsSave>();
        numberCoin.text = "Coins: " + coins.ToString();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("coin"))
        {
            coinsMax = SaveParams.numOfCoins;
            Destroy(collision.gameObject);
            coins += 1;
            numberCoin.text = "Coins: " + coins.ToString() + " / " + coinsMax.ToString();
        }

    }
    // Update is called once per frame
    void Update()
    {
        coinsMax = SaveParams.numOfCoins;
        int check = numCoins.length;
        if(check == coins)
        {
            SceneManager.LoadScene("LastWindow");
        }
    }
}

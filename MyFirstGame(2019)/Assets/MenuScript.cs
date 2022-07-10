using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoMenu_click()
    {
        //Debug.Log("I am ready");
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        //Debug.Log("I am ready");
        Application.Quit();
    }

    public void Rules()
    {
        //Debug.Log("I am ready");
        SceneManager.LoadScene("Rules");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

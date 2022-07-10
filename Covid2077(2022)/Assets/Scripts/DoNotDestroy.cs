using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake(){
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if(musicObj.Length > 2){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}

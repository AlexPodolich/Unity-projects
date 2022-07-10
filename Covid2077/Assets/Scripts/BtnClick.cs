using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClick : MonoBehaviour
{
    private AudioSource sound;
    public AudioClip click;
    
    private void Awake() {
        sound = GetComponent<AudioSource>();
    }
 
    public void btnClicked(){
        sound.PlayOneShot(click, 1f);
    }
}

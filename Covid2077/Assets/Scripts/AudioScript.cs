using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private AudioSource sound;
    public AudioClip kill;
    public AudioClip explosion;
    public AudioClip bigExplosion;
    public AudioClip gameOver;
    public AudioClip background;
    private Player player;
    private bool isGameOver;
    private float timer;
    void Awake(){
        timer = 1f;
        isGameOver = false;
        player = FindObjectOfType<Player>();
    }
    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.clip = background;
        sound.volume = 0.05f;
        sound.loop = true;
        sound.Play();
    }

    void Update(){
        if(player.getLose() && !isGameOver){
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                sound.Stop();
                gameOverSound();
                isGameOver = true;
            }
        }
    }

    public void onKillSound(){
        sound.PlayOneShot(kill, 0.7f);
    }

    public void onExplosionSound(){
        sound.PlayOneShot(explosion, 0.7f);
    }

    public void onBigExplosionSound(){
        sound.PlayOneShot(bigExplosion, 1f);
    }
    
    public void gameOverSound(){
        sound.PlayOneShot(gameOver, 0.7f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObjects : MonoBehaviour
{
    public Image coronovirus;
    public GameObject medecine;
    private float timeToSpawn;
    private Player player;
    public Canvas gameCanvas;
    private float gameZoneHight;
    private float gameZoneWidth;
    void Awake(){
        player = FindObjectOfType<Player>();
        timeToSpawn = 2f;
    }
    
    void Start(){
        gameZoneHight = gameCanvas.GetComponent<RectTransform>().rect.height - 500;
        gameZoneWidth = gameCanvas.GetComponent<RectTransform>().rect.width;
    }

    void Update(){
        float timePlayed = player.getTimeInGame();
        float newTimeToSpawn;
        if(!player.getLose()){
            timeToSpawn -= Time.deltaTime;
            if (timeToSpawn <= 0)
            {
                Spawn();
                newTimeToSpawn = 2f - (timePlayed/10) * 0.12f;
                if(newTimeToSpawn < 0.175f){
                    newTimeToSpawn = 0.175f;
                }
                timeToSpawn = newTimeToSpawn;
            }
        }
    }

    void Spawn(){
        int number = Random.Range(1,10);
        float maxCoordX = gameZoneWidth - (250/2);
        float minCoordY = -(gameZoneHight - (250/2));
        float randCoordinateX = Random.Range(125f, maxCoordX);
        float randCoordinateY = Random.Range(minCoordY, -125f);
        if(number >= 2){
            Instantiate (coronovirus, new Vector2 (randCoordinateX, randCoordinateY), Quaternion.identity).transform.SetParent (GameObject.FindGameObjectWithTag("playingZone").transform, false);
        }else{
            Instantiate (medecine, new Vector2 (randCoordinateX, randCoordinateY), Quaternion.identity).transform.SetParent (GameObject.FindGameObjectWithTag("playingZone").transform, false);
        }
    }

    public float getTimeToSpawn(){
        return timeToSpawn;
    }

    public void setTimeToSpawn(float timeToSpawn){
        this.timeToSpawn = timeToSpawn;
    }
}

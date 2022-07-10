using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public ParamsSave SaveParams;
    public int length;
    public Vector3 center; // координаты центра
    public Vector3 size; // координаты в которых будут появляться объекты
    public GameObject monster; // сфера
    // Start is called before the first frame update
    void Start()
    {
        SaveParams = GameObject.Find("ParamsSave").GetComponent<ParamsSave>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        length = SaveParams.numOfMonsters;
    }

    public void Spawn()
    {
        length = SaveParams.numOfMonsters;
        for (int i = 0; i < length; i++)
        {
            Vector3 pos2 = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Instantiate(monster, pos2, Quaternion.identity);
        }
        
    }
}

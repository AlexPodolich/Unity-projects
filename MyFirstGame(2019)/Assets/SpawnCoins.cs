using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public ParamsSave SaveParams;
    public int length;
    public Vector3 center; // координаты центра
    public Vector3 size; // координаты в которых будут появляться объекты
    public GameObject coin; // наш куб

    // Start is called before the first frame update
    void Start()
    {
        SaveParams = GameObject.Find("ParamsSave").GetComponent<ParamsSave>();
        //numCoins = GameObject.Find("ParamsSave").GetComponent<ParamsSave>();
        Spawn();
        //print(numCoins.numOfCoins);
    }

    // Update is called once per frame
    void Update()
    {
        length = SaveParams.numOfCoins;
    }
    public void Spawn()
    {
        length = SaveParams.numOfCoins;
        for (int i = 0; i < length; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Instantiate(coin, pos, Quaternion.identity); // осуществляем появление объекта в заданных случайных позициях в диапазоне заданных координат
        }
        
    }
}

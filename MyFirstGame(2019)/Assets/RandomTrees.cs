using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTrees : MonoBehaviour
{
    public int length = 4;
    public Vector3 center; // координаты центра
    public Vector3 size; // координаты в которых будут появляться объекты
    public GameObject tree1; // наш куб
    public GameObject tree2;
    public GameObject tree3;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        for (int i = 0; i < length; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Instantiate(tree1, pos, Quaternion.identity);
            Vector3 pos1 = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Instantiate(tree2, pos1, Quaternion.identity);
            Vector3 pos2 = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Instantiate(tree3, pos2, Quaternion.identity);// осуществляем появление объекта в заданных случайных позициях в диапазоне заданных координат
        }

    }
}

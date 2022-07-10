using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public float objectRadius;
    public LayerMask filterMask; 
    private SpawnObjects spawner; 
    private Collider2D checkCollider; 

    void Awake()
    {
        spawner = FindObjectOfType<SpawnObjects>();
    }

    void Update()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        checkCollider = Physics2D.OverlapCircle(rectTransform.anchoredPosition, objectRadius, filterMask);
        if (checkCollider != null && checkCollider.transform != transform)
        {
            Destroy(checkCollider.gameObject);
            spawner.setTimeToSpawn(0);
        }
    }
}

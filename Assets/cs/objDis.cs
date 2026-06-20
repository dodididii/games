using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objDis : MonoBehaviour
{
    // 限制物体在一定范围内
    public float topBound = 27f;
    public float lowerBound = 18f;
    public float leftBound = -6f;
    public float rightBound = 6f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x<leftBound || transform.position.x>rightBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > topBound || transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}

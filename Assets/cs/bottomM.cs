using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class bottomM : MonoBehaviour
{
    public BaseMove data;
    private Vector3 startP;
    private Vector3 zBound;

    void Start()
    {
        startP = transform.position;
        zBound = startP;
        Debug.Log(startP);
        zBound.y += 2*data.bottomHeight;
        Debug.Log(zBound); 
    }
    void Update()
    {
        if (data.counter >= data.totolDeep - 2*data.bottomHeight && data.isMovingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, zBound, data.scrollSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, zBound) < 0.01f)
            {
                transform.position = zBound;
                data.isMovingForward = false; 
                data.counter += data.bottomHeight;
            }
        }
        // 下移逻辑
        else if (transform.position != startP && !data.isMovingForward)
        {
            Debug.Log("开始下移"); 
            
            transform.position = Vector3.MoveTowards(transform.position, startP, data.scrollSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startP) < 0.01f)
            {
                transform.position = startP;
                data.counter -= data.bottomHeight;
            }
        }
    }
    
    //移动

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class backgroundMove : MonoBehaviour
{
    public BaseMove data;    
    private Vector3 startP;
    private Vector3 zBound;
    private main mama;
    public bool isCounting = false;
    
    // Start is called before the first frame update
    void Start()
    {
        startP = transform.position;
        zBound = startP; 
    }

   
    void Update()
    {
        if(data.counter <= data.totolDeep  && data.counter>=0)
        {
            backMove();
        }
    }
    void backMove()
    { 
        float or = data.isMovingForward ? 1 : -1;
        zBound.y = startP.y +or * data.backgroundHeight;
        transform.position = Vector3.MoveTowards(transform.position, zBound,data.scrollSpeed*Time.deltaTime);
        if (transform.position == zBound)
        {
            transform.position = startP;
            //¼ÆÊý
            if(isCounting)
            {
                data.counter = data.counter+or * data.backgroundHeight;
            }   
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class uiTextDeep : MonoBehaviour
{
    public BaseMove data;
    public TextMeshPro deep;

    // Update is called once per frame
    void Update()
    {
        // 显示当前深度
        deep.text = "current depth :  " + (int)data.counter +"/"+data.totolDeep+ "\n" + 
            "current fish :" + (int)data.fishCount + "/" + data.caughtFish.Length;
    }
}

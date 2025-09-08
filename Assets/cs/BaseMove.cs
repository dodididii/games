using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "BaseMove", menuName = "BaseMove")]
public class BaseMove : ScriptableObject
{
    // 控制鱼钩和背景的移动
    public float scrollSpeed = 4f;
    // 背景和鱼钩的总深度
    public float totolDeep = 50f;
    // 计数器，记录移动了多少深度
    public float counter = 0f;
    // 背景和底部的高度
    public float backgroundHeight=10f;
    public float bottomHeight=10f;
    // 鱼钩是否在向下移动
    public bool isMovingForward = true;
    // 鱼的相关数据 
    public const int totolFish = 5;
    public GameObject[] caughtFish  = new GameObject[totolFish];
    public int fishCount = 0;
    public int fishScore = 0;

    private void Awake()
    {
        Debug.Log("数据文件创建时调用");
    }
    public void InitializeParameters()
    {
        this.counter = 0f;
        this.isMovingForward = true;
        this.fishCount = 0;
        this.fishScore = 0;
    }
}


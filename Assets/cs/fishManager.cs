using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//鱼的生成管理
public class fishManager : MonoBehaviour
{
    public GameObject[] fishPrefab = new GameObject[5];// 鱼的预制体
    public float minTime = 1f;
    public float maxTime = 3f;
    private float nextSpawnTime;
    public BaseMove data;

    void Start()
    {
        SetNextSpawnTime();
    }

   
    void Update()
    {
        if (Time.time >= nextSpawnTime && data.scrollSpeed !=0)
        {
            SpawnFish();
            SetNextSpawnTime();
        }
    }
    void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(minTime, maxTime);
    }
     void SpawnFish()
    {
        // 随机选择一个鱼的预制体
        int fishIndex = Random.Range(0, fishPrefab.Length - 1);
        if (data.counter>=data.totolDeep-2*data.bottomHeight)
        {
            //达到最大深度时可以生成最大的一种鱼
            fishIndex = Random.Range(0, fishPrefab.Length);
        }
        
        int y = 0;
        int x = 0;
        bool shouldRotate = Random.Range(0, 2) == 0; // 50%概率旋转
        Quaternion rotation = shouldRotate ?
            Quaternion.Euler(0, 180, 0) : // 绕y轴旋转180度
            fishPrefab[fishIndex].transform.rotation; // 保持原旋转
        if (shouldRotate) //鱼从右向左游
        {
            x = -6;
        }
        else
        {
            x = 6;
        }
        if (data.isMovingForward) //如果鱼钩向下
        {
            y = 13;
        }
        else//鱼钩向上
        {
            y = 26;
        }
        Instantiate(fishPrefab[fishIndex], new Vector3(x, y, 0), rotation);
    }
}

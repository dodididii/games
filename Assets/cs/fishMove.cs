using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class fishMove : MonoBehaviour
{
    public BaseMove data;
    public float fishSpeed = 1f;
    private bool isCaught = false; // 鱼是否被 钩住
    public int score = 10; // 鱼的分数

    [SerializeField] float shrinkDuration = 0.5f; // 缩小动画时长
    [SerializeField] AnimationCurve shrinkCurve = AnimationCurve.EaseInOut(0, 0, 1, 1); // 缩放曲线
    [SerializeField] bool destroyOnComplete = false; // 完成后是否销毁 物体
    // 可触发层级。。测试未添加有需要再加

    private Vector3 originalScale;
    private bool isAnimating = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (!isCaught)
        {
             fMove();
        }
       
    }
    //控制鱼的移动
    void fMove()
    {
        float or = data.isMovingForward ? 1 : -1;
        transform.Translate(Vector3.left * fishSpeed * Time.deltaTime +
            Vector3.up * or * data.scrollSpeed * Time.deltaTime, Space.Self);
    }

    //控制鱼被勾住
    private void OnTriggerEnter(Collider other)
    {
        isCaught = true;
        //生成的鱼名含有(Clone)需要去掉
        if (gameObject.name.Contains("(Clone)"))
        {
            gameObject.name = gameObject.name.Replace("(Clone)", "");
        }
        GameObject prefab = Resources.Load("mymp/" + gameObject.name) as GameObject;

        Debug.Log("Caught fish: " + prefab.name);
        data.caughtFish[data.fishCount] = prefab;             
        StartShrinkAnimation();
        data.fishCount++;       
    }

    public void StartShrinkAnimation()
    {
        if (!isAnimating)
        {
            StartCoroutine(ShrinkRoutine());
        }
    }
    IEnumerator ShrinkRoutine()
    {
        isAnimating = true;
        float elapsed = 0f;

        while (elapsed < shrinkDuration)
        {
            float progress = shrinkCurve.Evaluate(elapsed / shrinkDuration);
            transform.localScale = originalScale * (1 - progress);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero;
        if (destroyOnComplete)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}

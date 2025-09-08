using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookMove : MonoBehaviour
{
    public GameObject target;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        hookController();
    }

    void hookController()
    {
        //按a向左移動，按d向右移動
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //还可以用触摸控制
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touchPosition.x < 0) // 左侧屏幕
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            else // 右侧屏幕
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }
        //限制移動範圍
        float clampedX = Mathf.Clamp(transform.position.x, -3f, 3f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

    }
}

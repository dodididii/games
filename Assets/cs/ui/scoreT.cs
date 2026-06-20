using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreT : MonoBehaviour
{
    public BaseMove data;
    public TextMeshPro score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "final score: " + (int)data.fishScore;
    }
}

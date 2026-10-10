using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class QuizQuestion : MonoBehaviour
{
    public string question;

    public string optionA;
    public string optionB;
    public string optionC;
    public string optionD;

    // 0 = A
    // 1 = B
    // 2 = C
    // 3 = D
    public int correctAnswer;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

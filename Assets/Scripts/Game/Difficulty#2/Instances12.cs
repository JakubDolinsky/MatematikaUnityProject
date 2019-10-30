using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instances12 : MonoBehaviour
{

    List<string> firstOptionn = new List<string>() { "11", "21", "16", "16", "15", "13", "40", "20", "9", "10"};

    void Start()
    {
       // GetComponent<TextMesh>().text = firstOption[0];
    }

    
    void Update()
    {
        if (GameController2.randomInstance > -1)
        {
            GetComponent<TextMesh>().text = firstOptionn[GameController2.randomInstance];
        }
    }

    void OnMouseDown()
    {
        GameController2.selectedAnswer = gameObject.name;
        GameController2.selectedChoice = "y";
    }
}

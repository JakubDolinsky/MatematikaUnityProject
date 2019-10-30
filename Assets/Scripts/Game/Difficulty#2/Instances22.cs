using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instances22 : MonoBehaviour
{

    List<string> secondOption = new List<string>() { "8", "14", "19", "11", "19", "11", "45", "22", "16", "11"};

    void Start()
    {
        //GetComponent<TextMesh>().text = secondOption[0];
    }


    void Update()
    {
        if (GameController2.randomInstance > -1)
        {
            GetComponent<TextMesh>().text = secondOption[GameController2.randomInstance];
        }
    }

    void OnMouseDown()
    {
        GameController2.selectedAnswer = gameObject.name;
        GameController2.selectedChoice = "y";
    }
}

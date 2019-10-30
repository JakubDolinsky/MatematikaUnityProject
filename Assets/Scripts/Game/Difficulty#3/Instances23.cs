using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instances23 : MonoBehaviour
{

    List<string> secondOption = new List<string>() { "20", "30", "59", "17", "19", "150", "100", "130", "4", "5"};

    void Start()
    {
        //GetComponent<TextMesh>().text = secondOption[0];
    }


    void Update()
    {
        if (GameController3.randomInstance > -1)
        {
            GetComponent<TextMesh>().text = secondOption[GameController3.randomInstance];
        }
    }

    void OnMouseDown()
    {
        GameController3.selectedAnswer = gameObject.name;
        GameController3.selectedChoice = "y";
    }
}

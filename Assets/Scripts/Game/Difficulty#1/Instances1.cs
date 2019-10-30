using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instances1 : MonoBehaviour
{

    public static List<string> firstOption = new List<string>() { "2", "2", "5", "6", "6", "3", "7", "1", "9", "3"};

    void Start()
    {
       // GetComponent<TextMesh>().text = firstOption[0];
    }

    
    void Update()
    {
        if (GameController.randomInstance > -1)
        {
            GetComponent<TextMesh>().text = firstOption[GameController.randomInstance];
        }
    }

    void OnMouseDown()
    {
        GameController.selectedAnswer = gameObject.name;
        GameController.selectedChoice = "y";
    }
}

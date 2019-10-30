using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instances2 : MonoBehaviour
{

    public static List<string> secondOption = new List<string>() { "8", "4", "9", "1", "9", "7", "25", "4", "7", "5"};

    void Start()
    {
        //GetComponent<TextMesh>().text = secondOption[0];
    }


    void Update()
    {
        if (GameController.randomInstance > -1)
        {
            GetComponent<TextMesh>().text = secondOption[GameController.randomInstance];
        }
    }

    void OnMouseDown()
    {
        GameController.selectedAnswer = gameObject.name;
        GameController.selectedChoice = "y";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instances32 : MonoBehaviour
{
    List<string> thirdOption = new List<string>() { "15", "18", "18", "15", "13", "17", "49", "19", "7", "8"};

    void Start()
    {
       // GetComponent<TextMesh>().text = thirdOption[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController2.randomInstance > -1)
        {
            GetComponent<TextMesh>().text = thirdOption[GameController2.randomInstance];
        }
    }

    void OnMouseDown()
    {
        GameController2.selectedAnswer = gameObject.name;
        GameController2.selectedChoice = "y";
    }
}

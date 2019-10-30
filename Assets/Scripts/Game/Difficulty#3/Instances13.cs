using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instances13 : MonoBehaviour
{

    List<string> firstOptionn = new List<string>() { "11", "19", "54", "0", "15", "100", "160", "160", "10", "1"};

    void Start()
    {
       // GetComponent<TextMesh>().text = firstOption[0];
    }

    
    void Update()
    {
        if (GameController3.randomInstance > -1)
        {
            GetComponent<TextMesh>().text = firstOptionn[GameController3.randomInstance];
        }
    }

    void OnMouseDown()
    {
        GameController3.selectedAnswer = gameObject.name;
        GameController3.selectedChoice = "y";
    }
}

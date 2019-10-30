using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instances33 : MonoBehaviour
{
    List<string> thirdOption = new List<string>() { "25", "28", "50", "28", "13", "200", "90", "138", "5", "3"};

    void Start()
    {
       // GetComponent<TextMesh>().text = thirdOption[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController3.randomInstance > -1)
        {
            GetComponent<TextMesh>().text = thirdOption[GameController3.randomInstance];
        }
    }

    void OnMouseDown()
    {
        GameController3.selectedAnswer = gameObject.name;
        GameController3.selectedChoice = "y";
    }
}

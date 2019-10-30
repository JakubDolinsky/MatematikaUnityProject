using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instances3 : MonoBehaviour
{
    List<string> thirdOption = new List<string>() { "5", "8", "5", "2", "2", "7", "3", "5", "2", "8"};

    void Start()
    {
       // GetComponent<TextMesh>().text = thirdOption[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.randomInstance > -1)
        {
            GetComponent<TextMesh>().text = thirdOption[GameController.randomInstance];
        }
    }

    void OnMouseDown()
    {
        GameController.selectedAnswer = gameObject.name;
        GameController.selectedChoice = "y";
    }
}

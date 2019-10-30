using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextIn : MonoBehaviour
{

    public static float timeToWait = 10f;

    public static float timeLeft;

    void Start()
    {
        
    }

    
    public static void Go()
    {
        if (timeLeft > 0)
        {
            Debug.Log("cc");
        }

        else
        {
            GameController.randomInstance = -1;
        }
    }
}

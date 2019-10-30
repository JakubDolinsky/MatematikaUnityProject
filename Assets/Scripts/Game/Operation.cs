using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation : MonoBehaviour
{

    public static int minRandom;
    public static int maxRandom;

    public void First()
    {
        minRandom = 0;
        maxRandom = 2;
    }

    public void Second()
    {
        minRandom = 3;
        maxRandom = 5;
    }

    public void Third()
    {
        minRandom = 6;
        maxRandom = 7;
    }

    public void Fourth()
    {
        minRandom = 8;
        maxRandom = 10;
    }

    public void Fifth()
    {
        minRandom = 0;
        maxRandom = 10;
    }

    void Reset()
    {
        minRandom = minRandom;
        maxRandom = maxRandom;

        GameController.timeLeft = 10f;
        GameController2.timeLeft = 10f;
        GameController3.timeLeft = 10f;
    }
}

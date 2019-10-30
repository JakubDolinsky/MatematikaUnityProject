using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bar : MonoBehaviour
{

    Image bar;

    public static float time = 10f;

    public static float timeLeft;

    

    void Start()
    {
        bar = GetComponent<Image>();
        timeLeft = time;
    }

    
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            bar.fillAmount = timeLeft / time;
        }

        else
        {
            Debug.Log("Cas vyprsal");
        }
    }
}

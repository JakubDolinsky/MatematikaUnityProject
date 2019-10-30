using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public void Play1()
    {
        SceneManager.LoadScene("Play1");
    }

    public void Play2()
    {
        SceneManager.LoadScene("Play2");
    }

    public void Play3()
    {
        SceneManager.LoadScene("Play3");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

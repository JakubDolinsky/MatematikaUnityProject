﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameController3 : MonoBehaviour
{

    List<string> instances = new List<string>() {"10 + 10 = ?", "20 + 10 = ?", " 30 + 20 = ?", "14 - 14 = ?", "30 - 15 = ?", "20 * 10 = ?", "10 * 10 = ?", "80 * 2 = ?", " 50 / 10 = ?", "30 / 30 = ?"};

    List<string> correctInstances = new List<string>() {"2", "2", "3", "1", "1", "3", "2", "1", "3", "1"};

    public Transform txtCorrect;
    public Transform txtInCorrect;

    public Transform firstCorrect;
    public Transform secondCorrect;
    public Transform thirdCorrect;

    public Transform firstInCorrect;
    public Transform secondInCorrect;
    public Transform thirdInCorrect;

    public AudioSource audioCorrect;
    public AudioSource audioUnCorrect;

    public Text txtTime;

    public static int randomInstance = -1;
    public static float timeLeft = 10f;

    public static string selectedAnswer;
    public static string selectedChoice = "n";

    public int correctAnswers;
    public int incorrectAnswers;

    void Start()
    {

    }

    
    void Update()
    {

        timeLeft -= Time.deltaTime;
        txtTime.text = (timeLeft).ToString("0");

        if (timeLeft < 0)
        {
            SceneManager.LoadScene("Play3");
            timeLeft = 10f;
        }

        txtCorrect.GetComponent<TextMesh>().text = "" + correctAnswers;
        txtInCorrect.GetComponent<TextMesh>().text = "" + incorrectAnswers;

        if (randomInstance == -1)
        {
            randomInstance = Random.Range(Operation.minRandom, Operation.maxRandom);
        }
        
        if(randomInstance > -1)
        {
            GetComponent<TextMesh>().text = instances[randomInstance];
        }
        
        if(selectedChoice == "y")
        {
            selectedChoice = "n";

            if (correctInstances[randomInstance] == selectedAnswer && selectedAnswer == "1")
            {

                correctAnswers += 1;
                audioCorrect.Play();
                firstCorrect.gameObject.SetActive(true);
                Time.timeScale = 0;

                StartCoroutine(Timer());
            }




            else if (correctInstances[randomInstance] == selectedAnswer && selectedAnswer == "2")
            {
                correctAnswers += 1;
                audioCorrect.Play();
                secondCorrect.gameObject.SetActive(true);
                Time.timeScale = 0;

                StartCoroutine(Timer());

            }

            else if (correctInstances[randomInstance] == selectedAnswer && selectedAnswer == "3")
            {
                correctAnswers += 1;
                audioCorrect.Play();
                thirdCorrect.gameObject.SetActive(true);
                Time.timeScale = 0;

                StartCoroutine(Timer());

            }

            //WRONG
            //WRONG
            //WRONG

            else if (correctInstances[randomInstance] != selectedAnswer && selectedAnswer == "1" && correctInstances[randomInstance] == "2")
            {
                incorrectAnswers += 1;
                audioUnCorrect.Play();
                Time.timeScale = 0;

                firstInCorrect.gameObject.SetActive(true);
                secondCorrect.gameObject.SetActive(true);

                StartCoroutine(Timer());
            }

            else if (correctInstances[randomInstance] != selectedAnswer && selectedAnswer == "1" && correctInstances[randomInstance] == "3")
            {
                incorrectAnswers += 1;
                audioUnCorrect.Play();
                Time.timeScale = 0;

                firstInCorrect.gameObject.SetActive(true);
                thirdCorrect.gameObject.SetActive(true);

                StartCoroutine(Timer());
            }

            else if (correctInstances[randomInstance] != selectedAnswer && selectedAnswer == "2" && correctInstances[randomInstance] == "1")
            {
                incorrectAnswers += 1;
                audioUnCorrect.Play();
                Time.timeScale = 0;

                secondInCorrect.gameObject.SetActive(true);
                firstCorrect.gameObject.SetActive(true);

                StartCoroutine(Timer());
            }

            else if (correctInstances[randomInstance] != selectedAnswer && selectedAnswer == "2" && correctInstances[randomInstance] == "3")
            {
                incorrectAnswers += 1;
                audioUnCorrect.Play();
                Time.timeScale = 0;

                secondInCorrect.gameObject.SetActive(true);
                thirdCorrect.gameObject.SetActive(true);

                StartCoroutine(Timer());
            }

            else if (correctInstances[randomInstance] != selectedAnswer && selectedAnswer == "3" && correctInstances[randomInstance] == "1")
            {
                incorrectAnswers += 1;
                audioUnCorrect.Play();
                Time.timeScale = 0;

                thirdInCorrect.gameObject.SetActive(true);
                firstCorrect.gameObject.SetActive(true);

                StartCoroutine(Timer());
            }

            else if (correctInstances[randomInstance] != selectedAnswer && selectedAnswer == "3" && correctInstances[randomInstance] == "2")
            {
                incorrectAnswers += 1;
                audioUnCorrect.Play();
                Time.timeScale = 0;

                thirdInCorrect.gameObject.SetActive(true);
                secondCorrect.gameObject.SetActive(true);

                StartCoroutine(Timer());
            }

            else
            {
                incorrectAnswers += 1;
                audioUnCorrect.Play();
                randomInstance = Random.Range(Operation.minRandom, Operation.maxRandom);

                Bar.timeLeft = Bar.time;

                timeLeft = 10f;
            }
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(5);

        Debug.Log("aaaa");

        Time.timeScale = 1;

        Bar.timeLeft = Bar.time;
        GameController.randomInstance = Random.Range(Operation.minRandom, Operation.maxRandom);
        timeLeft = 10f;
        firstCorrect.gameObject.SetActive(false);
        secondCorrect.gameObject.SetActive(false);
        thirdCorrect.gameObject.SetActive(false);

        firstInCorrect.gameObject.SetActive(false);
        secondInCorrect.gameObject.SetActive(false);
        thirdInCorrect.gameObject.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SettingSoundAudioButtons : SettingMusicAudioButtons
{
    private string buttonOnName = "soundOn";
    private string buttonOffName = "soundOff";
    private string musicName = "soundClick";
    private string fileName = "save6.dat";
    SavedDatas saveDts = new SavedDatas();

    public override void OnclickButton1()
    {
        buttonOn.gameObject.SetActive(true);
        buttonOnValue = true;
        buttonOff.gameObject.SetActive(true);
        buttonOffValue = true;

        try
        {
            if (GetComponent<Button>() == buttonOn)
            {
                buttonOn.gameObject.SetActive(false);
                buttonOnValue = false;
                music.gameObject.SetActive(true);
                Save(saveDts);
            }
            else
            {
                buttonOff.gameObject.SetActive(false);
                buttonOffValue = false;
                music.gameObject.SetActive(false);
                Save(saveDts);
            }
        }
        catch (Exception ex)
        {

            print("saveError " + ex);
        }
    }

  public override  void Start()
    {
        try
        {
            foreach (Button btn in FindObjectsOfTypeButton())
            {
                if (btn.name == buttonOnName)
                {
                    buttonOn = btn;
                }
                else if (btn.name == buttonOffName)
                {
                    buttonOff = btn;
                }
            }
            foreach (AudioSource audio in FindObjectsOfTypeAudioSource())
            {
                if (audio.name == musicName)
                {
                    music = audio;
                }
            }
            Load(saveDts);

            buttonOn.gameObject.SetActive(buttonOnValue);
            buttonOff.gameObject.SetActive(buttonOffValue);
            music.gameObject.SetActive(buttonOffValue);
        }
        catch (Exception ex)
        {
            print("loadError " + ex);
        }
    }
}

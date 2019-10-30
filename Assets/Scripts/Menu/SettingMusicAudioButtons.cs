using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SettingMusicAudioButtons : MonoBehaviour
{
    private string buttonOnName = "musicOn";
    private string buttonOffName = "musicOff";
    private string musicName = "soundMain";
    private string fileName = "save5.dat";
    public bool buttonOnValue;
    public bool buttonOffValue;
    public Button buttonOn;
    public Button buttonOff;
    public AudioSource music;
    SavedDatas sdts = new SavedDatas();

    public virtual void OnclickButton1()
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
                Save(sdts);
            }
            else
            {
                buttonOff.gameObject.SetActive(false);
                buttonOffValue = false;
                music.gameObject.SetActive(false);
                Save(sdts);
            }
        }
        catch (Exception ex)
        {

            print("saveError " + ex);
        }
    }

    public void Save(SavedDatas sdt)
    {
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + fileName;
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream file = File.Create(path))
        {
            sdt.buttonOnValue = buttonOnValue;
            sdt.buttonOffValue = buttonOffValue;
            bf.Serialize(file, sdt);
        }
    }

    public void Load(SavedDatas sdt)
    {
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + fileName;
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream file = File.Open(path, FileMode.Open))
            {
                sdt = (SavedDatas)bf.Deserialize(file);
                buttonOnValue = sdt.buttonOnValue;
                buttonOffValue = sdt.buttonOffValue;
            }
        }
        else
        {
            buttonOnValue = false;
            buttonOffValue = true;
        }
    }

    public static List<Button> FindObjectsOfTypeButton()
    {
        List<Button> results = new List<Button>();
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects()
        .ToList().ForEach(g => results.AddRange(g.GetComponentsInChildren<Button>(true)));
        return results;
    }

    public static List<AudioSource> FindObjectsOfTypeAudioSource()
    {
        List<AudioSource> results = new List<AudioSource>();
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects()
        .ToList().ForEach(g => results.AddRange(g.GetComponentsInChildren<AudioSource>(true)));
        return results;
    }
    
    public virtual void Start()
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

            Load(sdts);

            buttonOn.gameObject.SetActive(buttonOnValue);
            buttonOff.gameObject.SetActive(buttonOffValue);
            music.gameObject.SetActive(buttonOffValue);
        }
        catch (Exception ex)
        {
            print("loadError " + ex);
        }
    }

    public void Update()
    {

    }
}

[Serializable]
public class SavedDatas
{
    public bool buttonOnValue;
    public bool buttonOffValue;
}

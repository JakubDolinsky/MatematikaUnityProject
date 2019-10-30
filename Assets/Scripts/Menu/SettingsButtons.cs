using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;


public class SettingsButtons : MonoBehaviour
{

    private List<string> buttonNames = new List<string> { "btnEasy", "btnMedium", "btnHard" };
    private List<string> playButtonNames = new List<string> { "btnPlay1", "btnPlay2", "btnPlay3" };
    private string fileName = "save1.dat";
    public List<bool> buttonValues;
    public List<Button> buttons;
    public List<Button> playButtons;

    public void OnclickButton1()
    {
        try
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].interactable = true;
                buttonValues[i] = true;
                playButtons[i].gameObject.SetActive(false);
            }
            switch (GetComponent<Button>().name)
            {
                case "btnEasy":
                    buttons[0].interactable = false;
                    buttonValues[0] = false;
                    playButtons[0].gameObject.SetActive(true);
                    Save();
                    break;
                case "btnMedium":
                    buttons[1].interactable = false;
                    buttonValues[1] = false;
                    playButtons[1].gameObject.SetActive(true);
                    Save();
                    break;
                case "btnHard":
                    buttons[2].interactable = false;
                    buttonValues[2] = false;
                    playButtons[2].gameObject.SetActive(true);
                    Save();
                    break;
            }
        }
        catch (Exception ex)
        {
            print("saveError " + ex);
        }
    }
    public void Save()
    {
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + fileName;
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream file = File.Create(path))
        {
            SavedData data = new SavedData();
            data.buttonValues = buttonValues;
            bf.Serialize(file, data);
        }
    }

    public void Load()
    {
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + fileName;
        if (File.Exists(path))
        {

            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream file = File.Open(path, FileMode.Open))
            {

                SavedData data = (SavedData)bf.Deserialize(file);
                buttonValues = data.buttonValues;
            }
        }
        else
        {
            buttonValues = new List<bool> { false, true, true };
        }
    }
  
    public static List<Button> FindObjectsOfTypeAll()
    {
        List<Button> results = new List<Button>();
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects().ToList().ForEach(g => results.AddRange(g.GetComponentsInChildren<Button>(true)));
        return results;
    }

    void Start()
    {
        try
        {
            buttons = new List<Button>();
            playButtons = new List<Button>();

            foreach (string n in buttonNames)
            {
                foreach (Button obj in FindObjectsOfTypeAll())
                {
                    if (obj.name == n)
                    {
                        buttons.Add(obj);
                    }
                }
            }

            foreach (string n in playButtonNames)
            {
                foreach (Button obj in FindObjectsOfTypeAll())
                {
                    if (obj.name == n)
                    {
                        playButtons.Add(obj);
                    }
                }
            }

            Load();

            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].interactable = buttonValues[i];
                playButtons[i].gameObject.SetActive(!buttonValues[i]);
            }
        }
        catch (Exception ex)
        {
            print("loadError " + ex);
        }
    }

 
    void Update()
    {

    }
}
[Serializable]
public class SavedData
{
    public List<bool> buttonValues;
}

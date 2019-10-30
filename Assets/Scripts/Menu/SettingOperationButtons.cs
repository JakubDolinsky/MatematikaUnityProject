using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SettingOperationButtons : MonoBehaviour
{
    private List<string> buttonNamesOp = new List<string> { "btn+", "btn-", "btnx", "btn/", "btnAll" };
    private string fileNameOp = "save2.dat";
    public List<bool> buttonValuesOp;
    public List<Button> buttonsOp;

    public void OnclickButton1()
    {
        try
        {
            for (int i = 0; i < buttonsOp.Count; i++)
            {
                buttonsOp[i].interactable = true;
                buttonValuesOp[i] = true;
            }
            switch (GetComponent<Button>().name)
            {
                case "btn+":
                    buttonsOp[0].interactable = false;
                    buttonValuesOp[0] = false;
                    Save();
                    break;
                case "btn-":
                    buttonsOp[1].interactable = false;
                    buttonValuesOp[1] = false;
                    Save();
                    break;
                case "btnx":
                    buttonsOp[2].interactable = false;
                    buttonValuesOp[2] = false;
                    Save();
                    break;
                case "btn/":
                    buttonsOp[3].interactable = false;
                    buttonValuesOp[3] = false;
                    Save();
                    break;
                case "btnAll":
                    buttonsOp[4].interactable = false;
                    buttonValuesOp[4] = false;
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
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + fileNameOp;
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream file = File.Create(path))
        {
            SavedData dataOp = new SavedData();
            dataOp.buttonValues = buttonValuesOp;
            bf.Serialize(file, dataOp);
        }
    }

    public void Load()
    {
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + fileNameOp;
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream file = File.Open(path, FileMode.Open))
            {
                SavedData dataOp = (SavedData)bf.Deserialize(file);
                buttonValuesOp = dataOp.buttonValues;
            }
        }
        else
        {
            buttonValuesOp = new List<bool> { true, true, true, true, true };
        }
    }

    void Start()
    {
        try
        {
            buttonsOp = new List<Button>();
            foreach (string btnName in buttonNamesOp)
            {
                buttonsOp.Add(GameObject.Find(btnName).GetComponent<Button>());
            }

            Load();

            for (int i = 0; i < buttonsOp.Count; i++)
            {
                buttonsOp[i].interactable = buttonValuesOp[i];
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

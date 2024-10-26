using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{
    private string path;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/gameData.json";
    }

    // Update is called once per frame
   
    public void SaveData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public PlayerData LoadData()
    {
        // Verificar si el archivo existe
        string path = Application.persistentDataPath + "/gameData.json";
        if (File.Exists(path))
        {
            // Leer el archivo JSON
            string json = File.ReadAllText(path);

            // Convertir el JSON a un objeto
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            return playerData;
        }
        else
        {
            return null;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color TeamColor = Color.white;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    [System.Serializable]
    public class SaveData
    {
        public Color teamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.teamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/saveData.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            TeamColor = data.teamColor;
        }
    }
}

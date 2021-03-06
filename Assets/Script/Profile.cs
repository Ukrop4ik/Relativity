﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class Profile : MonoBehaviour {

    public List<LevelData> levels = new List<LevelData>();
    public int levelcount;
    public string[] sceneid;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("skill_value"))
        {
            PlayerPrefs.SetInt("skill_value", 3);
            PlayerPrefs.Save();
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    [ContextMenu("CreateEmptyProfile")]
    public void CreateEmtyProfile()
    {
        
        List<LevelData> levels = new List<LevelData>();      

        for (int i = 0; i < 1; ++i)
        {
            LevelData Level = new LevelData(i, 0, 0, 0, 1);
            levels.Add(Level);
        }


        ProfileData data = new ProfileData(1, levels);

        JsonData jsonData = JsonMapper.ToJson(data);


        File.WriteAllText(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json", jsonData.ToString());
    }

    public void SaveProfile(List<LevelData> levels)
    {
        ProfileData data = new ProfileData(levels.Count, levels);

        JsonData jsonData = JsonMapper.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json", jsonData.ToString());
    }

    [ContextMenu("LoadProfile")]
    public void LoadProfile()
    {
        levels.Clear();

        if (!File.Exists(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json"))
        {
            CreateEmtyProfile();
        }

        JsonData data = DataLoad();
        for (int i = 0; i < data["Levels"].Count; i++)
        {
            LevelData l = new LevelData((int)data["Levels"][i]["levelnumber"], (int)data["Levels"][i]["levelstars"], (int)data["Levels"][i]["levelscore"], (double)data["Levels"][i]["leveltime"], (int)data["Levels"][i]["levelhard"]);
            levels.Add(l);
        }

        levelcount = levels.Count;
    }

    [ContextMenu("OpenProfileFolder")]
    public void OpenProfileFolder()
    {
        Process.Start(Application.persistentDataPath);
    }

    private static JsonData DataLoad()
    {
        string jsonstring = File.ReadAllText(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json");
        return JsonMapper.ToObject(jsonstring);
    }
}

public class ProfileData
{
    public int maxlevelcount = 0;
    public List<LevelData> Levels = new List<LevelData>();

    public ProfileData(int count, List<LevelData> data)
    {
        maxlevelcount = count;
        Levels = data;
    }
}

[System.Serializable]
public class LevelData
{
    public int levelnumber;
    public int levelstars;
    public int levelscore;
    public double leveltime;
    public int levelhard;

    public LevelData(int number, int stars, int score, double time, int hard)
    {
        levelhard = hard;
        levelnumber = number;
        levelstars = stars;
        levelscore = score;
        leveltime = time;

    }
}

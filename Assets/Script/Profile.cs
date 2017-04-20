using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Diagnostics;

public class Profile : MonoBehaviour {

    public List<LevelData> levels = new List<LevelData>();
    public int levelcount;

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
            LevelData Level = new LevelData(i, 0, 0, 0);
            levels.Add(Level);
        }


        ProfileData data = new ProfileData(1, levels);

        JsonData jsonData = JsonMapper.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json", jsonData.ToString());
    }

    [ContextMenu("LoadProfile")]
    public void LoadProfile()
    {

        if (!File.Exists(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json"))
        {
            CreateEmtyProfile();
        }

        JsonData data = DataLoad();
        for (int i = 0; i < data["Levels"].Count; i++)
        {
            LevelData l = new LevelData((int)data["Levels"][i]["levelnumber"], (int)data["Levels"][i]["levelstars"], (int)data["Levels"][i]["levelscore"], (double)data["Levels"][i]["leveltime"]);
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

    public LevelData(int number, int stars, int score, double time)
    {

        levelnumber = number;
        levelstars = stars;
        levelscore = score;
        leveltime = time;

    }
}

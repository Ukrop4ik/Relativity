using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;

public class LevelParams : MonoBehaviour {
    [SerializeField]
    UILevel ui;
    [SerializeField]
    int levelnumber;

    private List<int> nums = new List<int>();
    public int bonuscount;

    public void GetBonus()
    {
        bonuscount++;
        ui.starpanel.sprite = ui.stars[bonuscount - 1];
    }

    [ContextMenu("LevelWin")]
    public void LevelWin()
    {
        Profile profile = GameObject.Find("Profile").gameObject.GetComponent<Profile>();
        JsonData data = DataLoad();
        List<LevelData> levels = new List<LevelData>();

        for (int i = 0; i < data["Levels"].Count; i++)
        {
            if ((int)data["Levels"][i]["levelnumber"] == levelnumber)
            {
                LevelData lev = new LevelData(levelnumber, bonuscount, 0, 0);
                levels.Add(lev);
                nums.Add(i);
                continue;
            }

            nums.Add(i);
            LevelData l = new LevelData((int)data["Levels"][i]["levelnumber"], (int)data["Levels"][i]["levelstars"], (int)data["Levels"][i]["levelscore"], (double)data["Levels"][i]["leveltime"]);
            levels.Add(l);

        }

        if (!nums.Contains(levelnumber))
        {
            LevelData newlevel = new LevelData(levelnumber, bonuscount, 0, 0);
            levels.Add(newlevel);
        }

        profile.SaveProfile(levels);
    }

    private static JsonData DataLoad()
    {
        string jsonstring = File.ReadAllText(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json");
        return JsonMapper.ToObject(jsonstring);
    }
}

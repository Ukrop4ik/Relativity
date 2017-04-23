using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelParams : MonoBehaviour {
    [SerializeField]
    UILevel ui;
    [SerializeField]
    public int levelnumber;
    public float leveltime = 100;
    GameObject endtrigger;
    private List<int> nums = new List<int>();
    public int bonuscount;
    bool stop = false;

    void Start()
    {
        endtrigger = GameObject.Find("EndTrigger");
        endtrigger.SetActive(false);
    }

    public void GetBonus()
    {
        bonuscount++;
        ui.starpanel.sprite = ui.stars[bonuscount - 1];
        if (bonuscount > 0)
        {
            endtrigger.SetActive(true);
        }
    }

    void Update()
    {

        if (!stop) leveltime -= Time.deltaTime;

        if (leveltime <= 0)
        {
            leveltime = 0;
            LevelFail();
        }

        ui.timetext.text = leveltime.ToString("0");
    }

    [ContextMenu("LevelWin")]
    public void LevelWin()
    {
        Destroy(GameObject.Find("Player"));
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
        ui.WinPanel.SetActive(true);
        stop = true;

    }

    [ContextMenu("LevelFail")]
    public void LevelFail()
    {
        stop = true;
        Destroy(GameObject.Find("Player"));
        ui.LoosePanel.SetActive(true);
    }

    private static JsonData DataLoad()
    {
        string jsonstring = File.ReadAllText(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json");
        return JsonMapper.ToObject(jsonstring);
    }
}

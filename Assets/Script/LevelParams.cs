using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelParams : MonoBehaviour {
    [SerializeField]
    UILevel ui;
    public List<GameObject> bonuslist = new List<GameObject>();
    [SerializeField]
    public int levelnumber;
    public float leveltime = 100;
    GameObject endtrigger;
    private List<int> nums = new List<int>();
    public int bonuscount;
    bool stop = false;
    [Tooltip("1 to 5 level hard")]
    public int hard = 1;
    public bool win = false;

    void Start()
    {
        endtrigger = GameObject.Find("EndTrigger");
        endtrigger.SetActive(false);
        bonuslist.AddRange(GameObject.FindGameObjectsWithTag("Bonus"));
    }

    public void GetBonus()
    {
        if (bonuscount < 3)
        {
            bonuscount++;
            ui.starpanel.sprite = ui.stars[bonuscount - 1];
            if (bonuscount > 0)
            {
                endtrigger.SetActive(true);
            }
        }        
        if (bonuscount >= 3)
        {
            foreach (GameObject bonus in bonuslist)
            {
                Bonus b = bonus.GetComponent<Bonus>();
                b.SetEvil();
            }
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
                LevelData lev = new LevelData(levelnumber, bonuscount, 0, 0, hard);
                levels.Add(lev);
                nums.Add(i);
                continue;
            }

            nums.Add(i);
            LevelData l = new LevelData((int)data["Levels"][i]["levelnumber"], (int)data["Levels"][i]["levelstars"], (int)data["Levels"][i]["levelscore"], (double)data["Levels"][i]["leveltime"], (int)data["Levels"][i]["levelhard"]);
            levels.Add(l);

        }

        if (!nums.Contains(levelnumber))
        {
            LevelData newlevel = new LevelData(levelnumber, bonuscount, 0, 0, hard);
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
        ui.LoosePanel.SetActive(true);
        Destroy(GameObject.Find("Player"));
    }

    private static JsonData DataLoad()
    {
        string jsonstring = File.ReadAllText(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json");
        return JsonMapper.ToObject(jsonstring);
    }
}

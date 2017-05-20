using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatMenu : MonoBehaviour {
    public GameObject cheatmenu;
    private int clickcount;
    [SerializeField]
    UILevel ui;
    private LevelParams Lparams;

    // Use this for initialization


    void Start()
    {
        Lparams = GameObject.FindGameObjectWithTag("LevelParams").GetComponent<LevelParams>();

    }
    public void WinLevel()
    {
        Lparams.bonuscount = 3;
        Lparams.win = true;
        Lparams.LevelWin();
    }
    public void OpenAllLevel()
    {
        List<LevelData> levels = new List<LevelData>();

        if (File.Exists(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json"))
        {
            File.Delete(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json");
        }

        for (int i = 1; i < SceneManager.sceneCountInBuildSettings - 1; i++)
        {
            LevelData Level = new LevelData(i, 3, 0, 0, 1);
            levels.Add(Level);
        }
        ProfileData data = new ProfileData(SceneManager.sceneCountInBuildSettings - 2, levels);

        JsonData jsonData = JsonMapper.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json", jsonData.ToString());

        Destroy(GameObject.Find("Profile"));

        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    private static JsonData DataLoad()
    {
        string jsonstring = File.ReadAllText(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json");
        return JsonMapper.ToObject(jsonstring);
    }
    public void Click()
    {
        clickcount++;
        if (clickcount == 6)
        {
            Debug.Log("OpenCheatMenu!");
            clickcount = 0;
            cheatmenu.SetActive(true);
        }
    }

    public void Close()
    {
        clickcount = 0;
        cheatmenu.SetActive(false);
    }
    public void SetSkill()
    {
        int skillvalue = PlayerPrefs.GetInt("skill_value");
        skillvalue += 5;
        PlayerPrefs.SetInt("skill_value", skillvalue);
        PlayerPrefs.Save();
        ui.ShowSkills();
    }
    public void SetTime()
    {
        Lparams.leveltime = 999;
        Lparams.maxleveltime = 999;
    }
    public void SetHealth()
    {
        Lparams.Health(100);
    }
    public void ClearProfile()
    {
        PlayerPrefs.DeleteAll();
        if (File.Exists(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json"))
        {
            File.Delete(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json");
        }
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void SetTimeTo0()
    {
        Lparams.leveltime = 0;
    }
    public void SetHPTo0()
    {
        Lparams.Damage(999);
    }
    public void SetSKILLTo0()
    {
        PlayerPrefs.SetInt("skill_value", 0);
        PlayerPrefs.Save();
        ui.ShowSkills();
    }

}

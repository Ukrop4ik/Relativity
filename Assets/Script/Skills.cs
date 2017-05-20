using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour {
    UILevel ui;
    private LevelParams Lparams;

    void Start()
    {
        ui = gameObject.GetComponent<UILevel>();
        Lparams = GameObject.FindGameObjectWithTag("LevelParams").GetComponent<LevelParams>();
    }
    public void TimeButton()
    {
        if (PlayerPrefs.GetInt("skill_value") == 0)
        {
            ui.OpenRewardPanel();
            return;
        }
        Lparams.leveltime += 20f;
        if (Lparams.leveltime > Lparams.maxleveltime)
            Lparams.maxleveltime = Lparams.leveltime;
        SetSkill();
    }
    public void HPButton()
    {
        if (PlayerPrefs.GetInt("skill_value") == 0)
        {
            ui.OpenRewardPanel();
            return;
        } 
        Lparams.Health(100);
        SetSkill();
    }
    public void CollectButton()
    {
        if (PlayerPrefs.GetInt("skill_value") == 0)
        {
            ui.OpenRewardPanel();
            return;
        }
    }

    void SetSkill()
    {
        int skillvalue = PlayerPrefs.GetInt("skill_value");
        skillvalue -= 1;
        PlayerPrefs.SetInt("skill_value", skillvalue);
        PlayerPrefs.Save();
        ui.ShowSkills();
    }

}

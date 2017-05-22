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
        if (Lparams.playerHealth < 100) SetSkill();
    }
    public void CollectButton()
    {
        bool collectable = false;
        if (PlayerPrefs.GetInt("skill_value") == 0)
        {
            ui.OpenRewardPanel();
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        List<GameObject> bonuslist = new List<GameObject>();
        bonuslist.AddRange(Lparams.bonuslist);

        foreach (GameObject obj in bonuslist)
        {
            if (Vector3.Distance(obj.transform.position, player.transform.position) <= player.GetComponent<PointJump>().Max_join_dist)
            {
                obj.GetComponent<Bonus>().ManualCollect();
                collectable = true;
            }
        }
        if (collectable) SetSkill();
    }

    void SetSkill()
    {
        int skillvalue = PlayerPrefs.GetInt("skill_value");
        skillvalue -= 1;
        PlayerPrefs.SetInt("skill_value", skillvalue);
        PlayerPrefs.Save();
        ui.ShowSkills();
    }

    public void SkipLevelForBonus(GameObject panel)
    {
        int skillvalue = PlayerPrefs.GetInt("skill_value");
        skillvalue -= 3;
        PlayerPrefs.SetInt("skill_value", skillvalue);
        PlayerPrefs.Save();
        ui.ShowSkills();
        Lparams.bonuscount = 1;
        Lparams.win = true;
        panel.SetActive(false);
        Lparams.LevelWin();
    }

}

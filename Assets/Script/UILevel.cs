﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UILevel : MonoBehaviour {

    public GameObject LoosePanel;
    public GameObject WinPanel;

    bool pause = false;

    public Text bonus_text;


    public Sprite[] stars;


    public Image starpanel;

    LevelParams bonus_to_params;

    public Text timetext;

    void Start()
    {
        bonus_to_params = GameObject.FindGameObjectWithTag("LevelParams").GetComponent<LevelParams>();
    }

    public void PauseButton()
    {
        if (pause)
        {
            Time.timeScale = 1;
            pause = false;
        }
        else
        {
            Time.timeScale = 0;
            pause = true;
        }
    }
    public void UnjoinButton()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.SetParent(null);
    }
    public void Restart()
    {
        SceneManager.LoadScene(bonus_to_params.levelnumber.ToString());
    }
    public void NextLevel()
    {
        SceneManager.LoadScene((bonus_to_params.levelnumber + 1).ToString());
    }
    public void ToMainMenu()
    {
        GameObject profile = GameObject.Find("Profile");
        Destroy(profile);
        SceneManager.LoadScene("Menu");
    }

}

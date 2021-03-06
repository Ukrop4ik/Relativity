﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMainMenu : MonoBehaviour {

    public GameObject panelYesNo;


    public void Yes()
    {
        SoundManager manager = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundManager>();
        manager.PlaySound(AudioEnum.Click);
        Time.timeScale = 1;
        GameObject profile = GameObject.Find("Profile");
        Destroy(profile);
        SceneManager.LoadScene("Menu");
    }

    public void NO()
    {
        SoundManager manager = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundManager>();
        manager.PlaySound(AudioEnum.Click);
        Time.timeScale = 1;
        panelYesNo.SetActive(false);
    }

    public void Click()
    {
        SoundManager manager = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundManager>();
        manager.PlaySound(AudioEnum.Click);
        panelYesNo.SetActive(true);
    }
}

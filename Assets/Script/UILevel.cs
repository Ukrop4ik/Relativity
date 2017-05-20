﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UILevel : MonoBehaviour {

    public GameObject LoosePanel;
    public GameObject WinPanel;
    public Color timerred;
    public Color timerblue;
    bool pause = false;
    public Image starprogress;
 
    public Text bonus_text;


    public Sprite[] stars;

    public Image starpanel;

    LevelParams bonus_to_params;

    public Text timetext;
    public Text leveltext;
    [SerializeField]
    private Sprite pauseSprite;
    [SerializeField]
    private Sprite playSprite;
    [SerializeField]
    private Image pausebuttonimage;
    [SerializeField]
    private Image timebar;
    [SerializeField]
    private Text skill_value_text;
    [SerializeField]
    private Image hpbar;
    private float curramount;
    private float newammount;
    private float newHPammount;

    void Start()
    {
        bonus_to_params = GameObject.FindGameObjectWithTag("LevelParams").GetComponent<LevelParams>();
        leveltext.text = "LEVEL: " + bonus_to_params.levelnumber.ToString();

        ShowSkills();
    }

    public void ShowSkills()
    {
        skill_value_text.text = PlayerPrefs.GetInt("skill_value").ToString();
    }
    void Update()
    {
        if(starprogress.fillAmount != newammount)
            starprogress.fillAmount = Mathf.Lerp(starprogress.fillAmount, newammount, Time.deltaTime * 2f);
        if (hpbar.fillAmount != newHPammount)
            hpbar.fillAmount = Mathf.Lerp(hpbar.fillAmount, newHPammount, Time.deltaTime * 10f);

        timebar.fillAmount = Mathf.Lerp(timebar.fillAmount, bonus_to_params.GetTimeAmount(), Time.deltaTime * 5f); 
    }
    public void SetHpProgress(float amount)
    {
        newHPammount = amount;
    }
    public void SetStarsProgress(float amount)
    {
        newammount = amount;
    }
    public void SetTimerColorRed()
    {
        timetext.color = timerred;
    }
    public void SetTimerColorBlue()
    {
        timetext.color = timerblue;
    }
    public void PauseButton()
    {
        if (pause)
        {
            pausebuttonimage.sprite = pauseSprite;
            Time.timeScale = 1;
            pause = !pause;
        }
        else
        {
            pausebuttonimage.sprite = playSprite;
            Time.timeScale = 0.001f;
            pause = !pause;
        }
    }
    public void UnjoinButton()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        SoundManager manager = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundManager>();
        if (player.transform.parent) manager.PlaySound(AudioEnum.Unjoin);
        player.transform.SetParent(null);
  
    }
    public void ResterButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(bonus_to_params.levelnumber.ToString());
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

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

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
    [SerializeField]
    private GameObject boosttextwithwin;
    [SerializeField]
    private GameObject rewardvideopanel;
    [SerializeField]
    private GameObject finalrewardvideopanel;
    private float curramount;
    private float newammount;
    private float newHPammount;

    [SerializeField]
    private List<GameObject> arrowstoreward = new List<GameObject>();

    void Start()
    {
        bonus_to_params = GameObject.FindGameObjectWithTag("LevelParams").GetComponent<LevelParams>();
        leveltext.text = "LEVEL: " + bonus_to_params.levelnumber.ToString();
       // PauseButton();
        ShowSkills();
    }
    public void ShowWinBooster()
    {
        boosttextwithwin.SetActive(true);
    }
    public void OpenRewardPanel()
    {
        pause = true;
        rewardvideopanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void OpenRewardFinalPanel()
    {
        pause = true;
        finalrewardvideopanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void CloseGetReward()
    {
        pause = false;
        finalrewardvideopanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void CloseReward()
    {
        pause = false;
        rewardvideopanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ShowSkills()
    {
        skill_value_text.text = PlayerPrefs.GetInt("skill_value").ToString();
        if (PlayerPrefs.GetInt("skill_value") == 0)
        {
            skill_value_text.color = timerred;
            ShowArrow(true);
        }
        else
        {
            skill_value_text.color = Color.black;
            ShowArrow(false);
        }
    }
    void Update()
    {
        if (pause)
        {
            pausebuttonimage.sprite = playSprite;
            Time.timeScale = 0.001f;
        }

        else if (!Input.GetMouseButton(0))
        {
            pausebuttonimage.sprite = pauseSprite;

            Time.timeScale = 1f;
        }
         
        if (starprogress.fillAmount != newammount)
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

            pause = false;
        }
        else
        {

            pause = true;
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
        pause = false;
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
        pause = false;
        GameObject profile = GameObject.Find("Profile");
        Destroy(profile);
        SceneManager.LoadScene("Menu");
    }
    public void ShowArrow(bool isShow)
    {
        foreach (GameObject obj in arrowstoreward)
        {
            if (isShow)
                obj.SetActive(true);
            else
                obj.SetActive(false);
        }
    }

    public void SkipLevel()
    {
        bonus_to_params.bonuscount = 1;
        bonus_to_params.win = true;
        LoosePanel.SetActive(false);
        bonus_to_params.LevelWin();
    }


}

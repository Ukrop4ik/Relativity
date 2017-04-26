using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartMenu : MonoBehaviour {

    public GameObject buttonpref;
    public GameObject MainMenueUI;
    public GameObject LevelPanel;
    public Transform levelpanelcontent;
    private List<GameObject> buttons = new List<GameObject>();
    Profile profile;
    public Sprite[] stars;

    void Start()
    {
        profile = GameObject.Find("Profile").gameObject.GetComponent<Profile>();
    }

    public void CloseLevelPanel()
    {
    }

    public void OpenLevelPanel()
    {
        MainMenueUI.SetActive(!MainMenueUI.activeInHierarchy);
        LevelPanel.SetActive(!LevelPanel.activeInHierarchy);


        if (LevelPanel.activeInHierarchy)
        {
            if (levelpanelcontent.childCount > 0)
            {
                for (int i = 0; i < levelpanelcontent.childCount; i++)
                {
                    Destroy(levelpanelcontent.GetChild(i).gameObject);
                }
            }

        }

        if (!profile) return;
       // if(profile.levels.Count < 1) return;

        foreach (var button in buttons)
        {
            Destroy(button);
        }

        buttons.Clear();

        foreach (var scene in profile.levels)
        {
            if (scene.levelnumber == 0) continue;
            GameObject levelbutton = Instantiate(buttonpref);
            levelbutton.transform.SetParent(levelpanelcontent);
            levelbutton.GetComponent<LevelButton>().id = scene.levelnumber.ToString();
            
            switch (scene.levelstars)
            {
                case 0:
                    levelbutton.GetComponent<LevelButton>().starsimage.sprite = stars[0];
                    break;
                case 1:
                    levelbutton.GetComponent<LevelButton>().starsimage.sprite = stars[1];
                    break;
                case 2:
                    levelbutton.GetComponent<LevelButton>().starsimage.sprite = stars[2];
                    break;
                case 3:
                    levelbutton.GetComponent<LevelButton>().starsimage.sprite = stars[3];
                    break;
                default:
                    break;
            }
            buttons.Add(levelbutton);
        }

       // if (profile.levels.Count > 1) return;
        GameObject buttonnew = Instantiate(buttonpref);
        buttonnew.transform.SetParent(levelpanelcontent);
        buttonnew.GetComponent<LevelButton>().id = profile.levels.Count.ToString();
        buttonnew.GetComponent<LevelButton>().starsimage.sprite = stars[0];
    }

    void OpenProfile()
    {

    }
}

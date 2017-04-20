using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

    public GameObject buttonpref;
    public GameObject MainMenueUI;
    public GameObject LevelPanel;
    public Transform levelpanelcontent;

    Profile profile;

    void Start()
    {
        profile = GameObject.Find("Profile").gameObject.GetComponent<Profile>();
    }

    public void OpenLevelPanel()
    {
        MainMenueUI.SetActive(!MainMenueUI.activeInHierarchy);
        LevelPanel.SetActive(!LevelPanel.activeInHierarchy);
    }

    void OpenProfile()
    {

    }
}

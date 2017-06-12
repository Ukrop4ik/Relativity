using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LangPanel : MonoBehaviour {

    public List<Sprite> sprites = new List<Sprite>();
    public Image currentimage;
    public GameObject selectpanel;
    public Button selectbutton;

	// Use this for initialization
	void Start () {

        int L = 0;

        if (PlayerPrefs.GetInt("LangDefault") != 1)
        {
            if (Application.systemLanguage.ToString() != "Russian")
            {
                PlayerPrefs.SetInt("LANG", 1);
                PlayerPrefs.Save();
            }
            else
            {
                PlayerPrefs.SetInt("LANG", 0);
                PlayerPrefs.Save();
            }

            PlayerPrefs.SetInt("LangDefault", 1);
            PlayerPrefs.Save();
            UpdateUiLang();
        }

        L = PlayerPrefs.GetInt("LANG");
        currentimage.sprite = sprites[L];
		
	}

    public void OpenPanel()
    {
        selectpanel.SetActive(true);
        selectbutton.interactable = false;
    }

    public void SelectLang(int value)
    {
        selectpanel.SetActive(false);
        selectbutton.interactable = true;
        PlayerPrefs.SetInt("LANG", value);
        PlayerPrefs.Save();

        int L = 0;
        L = PlayerPrefs.GetInt("LANG");
        currentimage.sprite = sprites[L];

        UpdateUiLang();
    }

    public void UpdateUiLang()
    {
        List<GameObject> textobj = new List<GameObject>();
        textobj.AddRange(GameObject.FindGameObjectsWithTag("Text"));

        foreach (GameObject obj in textobj)
        {
            obj.GetComponent<Localization>().Change();
        }
    }
	
}

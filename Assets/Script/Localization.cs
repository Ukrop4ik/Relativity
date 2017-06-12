using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Localization : MonoBehaviour {

    private Text textfield;

    public string RU;
    public string EN;

    void Start()
    {
        Change();
    }

    void GetTextfield()
    {
        textfield = gameObject.GetComponent<Text>();
    }

    void OnEnable()
    {
        Change();
    }

    public void Change()
    {


        GetTextfield();


        if (!textfield) return;
        if (string.IsNullOrEmpty(RU) || string.IsNullOrEmpty(EN)) return;

        int L = 0;
        L = PlayerPrefs.GetInt("LANG");
        if (L == 0)
        {
            textfield.text = RU;
        }
        else
        {
            textfield.text = EN;
        }
    }
    
}

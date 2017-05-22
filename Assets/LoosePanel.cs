using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoosePanel : MonoBehaviour {

    [SerializeField]
    Button bonusbutton;


    void OnEnable()
    {
        if (PlayerPrefs.GetInt("skill_value") < 3)
        {
            bonusbutton.interactable = false;
        }
        else
        {
            bonusbutton.interactable = true;
        }
    }
	
}

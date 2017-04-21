using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UILevel : MonoBehaviour {

    public Text bonus_text;


    public Sprite[] stars;


    public Image starpanel;

    LevelParams bonus_to_params;


    void Start()
    {
        bonus_to_params = GameObject.FindGameObjectWithTag("LevelParams").GetComponent<LevelParams>();
    }
}

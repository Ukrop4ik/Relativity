using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour {

    private LevelParams bonus_to_params;
    private bool trigger1 = false;
    public GameObject tutorial2panel;
    void Start()
    {
        bonus_to_params = GameObject.FindGameObjectWithTag("LevelParams").GetComponent<LevelParams>();
    }
    void Update()
    {
        if (trigger1 == false)
        {
            if (bonus_to_params.bonuscount > 0)
            {
                tutorial2panel.SetActive(true);
                trigger1 = true;
            }
        }
    }
}

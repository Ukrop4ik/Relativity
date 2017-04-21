using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelParams : MonoBehaviour {
    [SerializeField]
    UILevel ui;

    public int bonuscount;

    public void GetBonus()
    {
        bonuscount++;
        ui.starpanel.sprite = ui.stars[bonuscount - 1];
    }
}

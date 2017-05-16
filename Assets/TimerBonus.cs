using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBonus : MonoBehaviour {

    LevelParams LevelParams;
    public float Value;
    public bool isEvil = false;
    public GameObject plane;

    void Start() {

        LevelParams = GameObject.FindGameObjectWithTag("LevelParams").GetComponent<LevelParams>();

        if (isEvil)
        {
            plane.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            plane.GetComponent<Renderer>().material.color = Color.green;
        }
        
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SoundManager manager = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundManager>();
            LevelParams.leveltime += isEvil ? -Value : Value;
            if (LevelParams.leveltime > LevelParams.maxleveltime)
                LevelParams.maxleveltime = LevelParams.leveltime;
            Destroy(this.gameObject);

        }
    }

}

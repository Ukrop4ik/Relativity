using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

    public GameObject text;
    LevelParams bonus_to_params;


    void Start()
    {
        bonus_to_params = GameObject.FindGameObjectWithTag("LevelParams").GetComponent<LevelParams>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && bonus_to_params.bonuscount > 0)
        {
            Time.timeScale = 0;
            text.SetActive(true);
        }
    }
}


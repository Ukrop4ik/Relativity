using UnityEngine;
using UnityEngine.SceneManagement;
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
            SoundManager manager = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundManager>();
            manager.PlaySound(AudioEnum.EndLevel);
            bonus_to_params.win = true;
            bonus_to_params.LevelWin();
        }
    }
}


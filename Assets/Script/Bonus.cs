using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

    LevelParams bonus_to_params;
    [SerializeField]
    int bonus_value;

    void Start()
    {
        bonus_to_params = GameObject.FindGameObjectWithTag("LevelParams").GetComponent<LevelParams>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collect!");
            bonus_to_params.SetBonus(bonus_value);
            Destroy(gameObject);
            
        }
    }
}

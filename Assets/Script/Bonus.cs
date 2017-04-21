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
            bonus_to_params.GetBonus();
            Debug.Log("Collect!");
            Destroy(gameObject);
            
        }
    }
}

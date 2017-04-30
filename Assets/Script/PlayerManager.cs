using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {


    [SerializeField]
    int Health;
    private LevelParams bonus_to_params;

    void Start()
    {
        bonus_to_params = GameObject.FindGameObjectWithTag("LevelParams").GetComponent<LevelParams>();
        transform.SetParent(null);
    }

    void Update()
    {

    }

    public void SetHealt(int value, bool damage = true)

    {
 
    }
    void OnDestroy()
    {
        if (!bonus_to_params.win) bonus_to_params.LevelFail();
    }

}

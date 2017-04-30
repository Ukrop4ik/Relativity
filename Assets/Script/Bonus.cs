using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

    LevelParams bonus_to_params;
    [SerializeField]
    int bonus_value;
    public bool isEvil;
    [SerializeField]
    GameObject normal;
    [SerializeField]
    GameObject agression;
    void Start()
    {
        bonus_to_params = GameObject.FindGameObjectWithTag("LevelParams").GetComponent<LevelParams>();
        if (isEvil) SetEvil();
    }
    public void SetEvil()
    {
        isEvil = true;
        normal.SetActive(false);
        agression.SetActive(true);
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isEvil)
            {
                bonus_to_params.LevelFail();
            }

            bonus_to_params.GetBonus();
            Debug.Log("Collect!");
            if (bonus_to_params.bonuslist.Contains(this.gameObject))
            {
                bonus_to_params.bonuslist.Remove(this.gameObject);
            }
            Destroy(gameObject);
            
        }
    }
}

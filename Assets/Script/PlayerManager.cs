using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {


    [SerializeField]
    int Health;


    void Update()
    {
        if (Health <= 0)
        {
            Debug.Log("You Dead");
        }
    }

    public void SetHealt(int value, bool damage = true)

    {
        if (damage)
        {
            Health -= value;
        }
        else Health += value;
    }

}

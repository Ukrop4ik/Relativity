using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {


    [SerializeField]
    int Health;

    void Start()
    {
        transform.SetParent(null);
    }

    void Update()
    {

    }

    public void SetHealt(int value, bool damage = true)

    {
 
    }

}

using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

    public GameObject text;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            text.SetActive(true);
        }
    }
}


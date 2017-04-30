using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    public List<GameObject> activationobj = new List<GameObject>();
    public GameObject activeeffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject obj in activationobj)
            {
                obj.SetActive(true);
                Instantiate(activeeffect, obj.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}

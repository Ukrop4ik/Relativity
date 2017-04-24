using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    [SerializeField]
    GameObject enablebubble;
    [SerializeField]
    bool finalbubble = false;
    [SerializeField]
    GameObject bubblepanel;
    
    public Transform pivot;

    void Start()
    {
        Time.timeScale = 0;
        if(pivot) transform.position = Camera.main.WorldToScreenPoint(pivot.position);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
       if (enablebubble)enablebubble.SetActive(true);

        if (finalbubble)
        {
            Time.timeScale = 1;
            bubblepanel.SetActive(false);

        }
    }
}

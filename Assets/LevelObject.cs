using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{


    void Start()
    {
        Vector3 pos = new Vector3(transform.position.x, 0, transform.position.z);
        transform.position = pos;

    }
}
	


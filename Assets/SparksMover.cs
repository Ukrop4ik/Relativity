using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksMover : MonoBehaviour {

    public Vector3 target;

    void Start()
    {
        Destroy(this.gameObject, 2f);
    }
	// Update is called once per frame
	void Update () {

        transform.Translate(target * Time.deltaTime);
	}
}

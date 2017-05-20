using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour {
    Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        this.transform.position = new Vector3(player.position.x, 100f, player.position.z + 5f);
    }
	
	// Update is called once per frame
	void Update () {

        if (player == null) return;

        if (this.transform.position.y > 35f)
            this.transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y , 35f, Time.deltaTime*0.8f), player.position.z + 5f);
        this.transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + 5f);


    }
}

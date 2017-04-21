using UnityEngine;
using System.Collections;

public class ShouRasius : MonoBehaviour {


    ParticleSystem radius;
    GameObject player;
    private float value;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        radius = gameObject.GetComponent<ParticleSystem>();
       

    }
    void Update()
    {
        value = player.GetComponent<PointJump>().Max_join_dist;
       // radius.startSize = value;
        radius.gameObject.transform.localScale = new Vector3(value, value, value);
    }
}

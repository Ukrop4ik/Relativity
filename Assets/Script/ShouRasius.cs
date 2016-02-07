using UnityEngine;
using System.Collections;

public class ShouRasius : MonoBehaviour {


    ParticleSystem radius;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        radius = gameObject.GetComponent<ParticleSystem>();
    }
    void Update()
    {
        radius.startSize = player.GetComponent<PointJump>().Max_join_dist +0.5f;
    }
}

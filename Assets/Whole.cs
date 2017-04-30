using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whole : MonoBehaviour {

    public Transform exit;
    public ParticleSystem warp;
    public ParticleSystem inwarp;

    void Start()
    {
        warp.Simulate(0f);
        inwarp.Simulate(0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(null);
            other.gameObject.transform.position = exit.position;
            warp.Play();
            inwarp.Play();
        }
    }

    public void OnPlayerClick()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.gameObject.transform.SetParent(null);
        player.gameObject.transform.position = exit.position;
        warp.Play();
        inwarp.Play();
    }
}

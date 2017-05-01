using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomSphere : MonoBehaviour {

    Color c;
    Renderer r;
    public float timescale = 0;
    public GameObject boomeffect;

    void Start()
    {
        c = gameObject.GetComponent<Renderer>().materials[0].color;
        r = gameObject.GetComponent<Renderer>();
    }
    void Update()
    {
        if (gameObject.transform.childCount > 0)
        {
            c.g -= Time.deltaTime * timescale;
            r.materials[0].color = c;
            if (c.g < 0.1f)
            {
                SoundManager manager = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundManager>();
                manager.PlaySound(AudioEnum.Boom);
                Instantiate(boomeffect, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject.transform.GetChild(0).gameObject);
                Destroy(this.gameObject);
            }
        }
        else if (c.g < 1)
        {
            c.g += Time.deltaTime * timescale;
            r.materials[0].color = c;
        }

    }
}

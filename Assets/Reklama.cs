using admob;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reklama : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Admob.Instance().initAdmob("ca-app-pub-4167355602558364/4713110533", "ca-app-pub-4167355602558364/1759644135");//admob id with format ca-app-pub-279xxxxxxxx/xxxxxxxx

        Invoke("Load", 3f);
    }

    // Update is called once per frame
    void Load()
    {
        Admob.Instance().loadInterstitial();
        Invoke("Show", 5f);
    }
    void Show()
    {
        if (Admob.Instance().isInterstitialReady())
        {
            Admob.Instance().showInterstitial();
        }
    }
}

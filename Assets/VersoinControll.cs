using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class VersoinControll : MonoBehaviour {

    public int version;

    void Start()
    {
        if (PlayerPrefs.GetInt("version") != version)
        {

            if (File.Exists(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json"))
            {
                File.Delete(Application.persistentDataPath + "/" + "RelatyvityProfile" + ".json");
            }

            PlayerPrefs.SetInt("skill_value", 0);
            PlayerPrefs.SetInt("version", version);
            PlayerPrefs.Save();


        }
    }
}

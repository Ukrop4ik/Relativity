using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMainMenu : MonoBehaviour {

    public GameObject panelYesNo;

    public void Yes()
    {
        Time.timeScale = 1;
        GameObject profile = GameObject.Find("Profile");
        Destroy(profile);
        SceneManager.LoadScene("Menu");
    }

    public void NO()
    {
        Time.timeScale = 1;
        panelYesNo.SetActive(false);
    }

    public void Click()
    {
        Time.timeScale = 0;
        panelYesNo.SetActive(true);
    }
}

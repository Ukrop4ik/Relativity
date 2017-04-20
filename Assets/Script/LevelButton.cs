using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {
    public int id;
    public Image starsimage;
    public Text number;

    void Start()
    {
        number.text = id.ToString();
    }
    public void Click()
    {
        SceneManager.LoadScene(id.ToString());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {
    public string id;
    public Image starsimage;
    public Text number;
    public Image image;
    public Sprite colour;
    public Image centerimage;
    void Start()
    {
        number.text = id;
    }
    public void Click()
    {
        SceneManager.LoadScene(id);
    }
}

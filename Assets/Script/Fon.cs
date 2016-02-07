using UnityEngine;
using System.Collections;

public class Fon : MonoBehaviour {


    float value;
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        value += Time.deltaTime*speed;
        gameObject.GetComponent<MeshRenderer>().sharedMaterial.SetTextureOffset("_MainTex", new Vector2(1, -value));
    }
}

using UnityEngine;
using System.Collections;
public class Rotation : MonoBehaviour {


    public float rotation_speed;




    void Update () {

            transform.Rotate(0, rotation_speed * Time.deltaTime, 0);
               
	}

}

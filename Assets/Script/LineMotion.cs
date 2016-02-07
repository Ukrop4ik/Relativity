using UnityEngine;
using System.Collections;

public class LineMotion : MonoBehaviour {

    public GameObject end_path;
    public float deltaX;
    public float deltaY;
    public float deltaZ;
    public float maxPath;
    public float path;

    public enum Direction
    {
        forward,
        back
    }
    public Direction dir;

	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {

        



        if (dir == Direction.forward)
        {
            transform.Translate(deltaX * Time.deltaTime, deltaY * Time.deltaTime, deltaZ * Time.deltaTime);
            path += deltaX;
            if (path >= maxPath)
            {
                dir = Direction.back;
                path = 0;
            }
        }
        else
        {
            transform.Translate(-deltaX * Time.deltaTime, -deltaY * Time.deltaTime, -deltaZ * Time.deltaTime);
            path += deltaX;
            if (path >= maxPath)
            {
                dir = Direction.forward;
                path = 0;
            }

        }
	}
}

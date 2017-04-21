using UnityEngine;
using System.Collections;


public class PointJump : MonoBehaviour {

    GameObject jump;
    public float Max_join_dist;
    LineRenderer joinline;
	// Use this for initialization
	void Start () {

        joinline = gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        joinline.SetPosition(0, gameObject.transform.position);

        if (gameObject.transform.parent)
        {
            joinline.enabled = true;
            joinline.SetPosition(1, gameObject.transform.parent.transform.position);
        }
        else
        {
            joinline.enabled = false;
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {

                if (hit.collider.gameObject.tag == "Jump")
                {
                    float dist = Vector3.Distance(hit.collider.gameObject.transform.position, transform.position);
                    if (dist <= Max_join_dist)
                    {
                        gameObject.transform.SetParent(null);
                        gameObject.transform.SetParent(hit.collider.gameObject.transform);
                    }
                }
                if (hit.collider.gameObject.tag == "Player")
                {
                    gameObject.transform.SetParent(null);
                    
                }
            }
        }

	}
}

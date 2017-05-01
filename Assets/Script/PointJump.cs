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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Max_join_dist);
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
                        SoundManager manager = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundManager>();
                        manager.PlaySound(AudioEnum.Join);
                        gameObject.transform.SetParent(null);
                        gameObject.transform.SetParent(hit.collider.gameObject.transform);
                    }
                }
                if (hit.collider.gameObject.tag == "Player")
                {
                    gameObject.transform.SetParent(null);
                    
                }
                if (hit.collider.gameObject.tag == "Whole")
                {
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    float dist;
                    dist = Vector3.Distance(player.transform.position, hit.collider.gameObject.transform.position);

                    if (dist <= Max_join_dist)
                    {
                        hit.collider.gameObject.GetComponent<Whole>().OnPlayerClick();
                    }
                
                }
            }
        }

	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class PointJump : MonoBehaviour
{

    GameObject jump;
    public float Max_join_dist;
    LineRenderer joinline;
    GameObject joinobj;
    public float timescale = 0.3f;
    int layermask = 1 << 5;
    bool startdrag = false;
    // Use this for initialization

    bool isUi;
    void Start()
    {

        joinline = gameObject.GetComponent<LineRenderer>();
        layermask = ~layermask;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Max_join_dist);
    }

    // Update is called once per frame
    void Update()
    {

        joinline.SetPosition(0, gameObject.transform.position);

        if (Input.GetMouseButton(0))
        {

            Time.timeScale = Mathf.Lerp(Time.timeScale, timescale, Time.deltaTime * 2);

            startdrag = true;
            Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit1;
            if (Physics.Raycast(ray1, out hit1, 1000, layermask))
            {

                if (Vector3.Distance(new Vector3(hit1.point.x, 0, hit1.point.z), gameObject.transform.position) <= Max_join_dist + 2f)
                {
                    joinline.SetPosition(1, new Vector3(hit1.point.x, 0, hit1.point.z));
                    joinline.enabled = true;
                }
                else
                {
                    joinline.SetPosition(1, gameObject.transform.position);
                    joinline.enabled = false;
                }
                if (Vector3.Distance(new Vector3(hit1.point.x, 0, hit1.point.z), gameObject.transform.position) <= 15f)
                {
                    gameObject.transform.SetParent(null);
                    joinobj = null;
                }

            }
            else
            {
                return;
            }


        }
        else if (Input.GetMouseButtonUp(0))
        {
            startdrag = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, layermask))
            {
                joinline.SetPosition(1, new Vector3(hit.point.x, 0, hit.point.z));

                if (hit.collider.gameObject.tag == "Jump")
                {
                    float dist = Vector3.Distance(hit.collider.gameObject.transform.position, transform.position);
                    if (dist <= Max_join_dist)
                    {
                        joinline.enabled = true;
                        SoundManager manager = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundManager>();
                        manager.PlaySound(AudioEnum.Join);
                        gameObject.transform.SetParent(null);
                        gameObject.transform.SetParent(hit.collider.gameObject.transform);
                        joinobj = hit.collider.gameObject;
                        hit.collider.gameObject.GetComponent<LineMotionPro>().isActive = true;
                    }
                }
                if (hit.collider.gameObject.tag == "Player")
                {
                    gameObject.transform.SetParent(null);
                    joinobj = null;

                }
                if (hit.collider.gameObject.tag == "" && gameObject.transform.parent != null)
                {
                    gameObject.transform.SetParent(null);
                    joinobj = null;
                    SoundManager somanager = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundManager>();
                    somanager.PlaySound(AudioEnum.Unjoin);
                    return;
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
            else
            {
                return;
            }



        }

        if (!startdrag)
        {
            if (gameObject.transform.parent)
            {
                joinline.SetPosition(1, gameObject.transform.parent.transform.position);
            }
            else
            {
                joinline.enabled = false;
            }
        }
    }

}

    

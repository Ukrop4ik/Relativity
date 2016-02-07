using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class LinePoint : MonoBehaviour {

    [SerializeField]
    GameObject starttarget;
    [SerializeField]
    GameObject endtarget;
    [SerializeField]
    LineRenderer line;
	void Start () {

        if (!Application.isPlaying)
        {
            line.SetPosition(0, starttarget.transform.position);
            line.SetPosition(1, endtarget.transform.position);
        }
        else line.enabled = false;
    }
}

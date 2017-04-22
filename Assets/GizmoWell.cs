using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoWell : MonoBehaviour {

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, new Vector3(1,5,100));
    }
}

using UnityEngine;
using System.Collections;

public class LineMotionPro : MonoBehaviour {
    public GameObject StartTarget;
    public GameObject EndTarget;
    public float TimeOfOneTrace = 1;

    private float _t = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!StartTarget || !EndTarget) return;

        if (TimeOfOneTrace < 0.001)
        {
            return;
        }

        float delta = (float)Time.deltaTime;

        _t += delta / TimeOfOneTrace;

        while (_t > 1)
        {
            _t -= 2;
        }

        var perm = _t < 0 ? -_t : _t;

        var dest = new Vector3(
StartTarget.transform.position.x + (EndTarget.transform.position.x - StartTarget.transform.position.x) * perm - gameObject.transform.position.x,
StartTarget.transform.position.y + (EndTarget.transform.position.y - StartTarget.transform.position.y) * perm - gameObject.transform.position.y,
StartTarget.transform.position.z + (EndTarget.transform.position.z - StartTarget.transform.position.z) * perm - gameObject.transform.position.z
    );
        transform.Translate(dest.x, dest.y, dest.z);
    }

}
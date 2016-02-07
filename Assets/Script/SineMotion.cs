using UnityEngine;

public class SineMotion: MonoBehaviour
{
    public GameObject StartTarget;
    public GameObject EndTarget;
    public float Cycles = 8;
    public float TimeOfOneTrace = 1;
    private const float _fuckingMathPi = 3.141592653589793f;

    private float _t = 0;

    // Use this for initialization
    void Start()
    {

    }

    protected bool TryExaminePermutation(out float perm)
    {
        //if (TimeOfOneTrace < 0.001)
        //{
        //    return false;
        //}

        float delta = (float)Time.deltaTime;

        _t += delta / TimeOfOneTrace;

        while (_t > 1)
        {
            _t -= 2;
        }

        perm = _t < 0 ? -_t : _t;
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        float perm;
        if (!TryExaminePermutation(out perm))
        {
            return;
        }

        var toEnd = new Vector3(
EndTarget.transform.position.x - StartTarget.transform.position.x,
EndTarget.transform.position.y - StartTarget.transform.position.y,
EndTarget.transform.position.z - StartTarget.transform.position.z
    );


        var il = 1.0f / Mathf.Sqrt(toEnd.x * toEnd.x + toEnd.z * toEnd.z);

        var normx = -toEnd.z * il;
        var normz = toEnd.x * il;

        var shiftT = Mathf.Sin(perm * Cycles * _fuckingMathPi);

        var dest = new Vector3(
StartTarget.transform.position.x + (EndTarget.transform.position.x - StartTarget.transform.position.x) * perm - gameObject.transform.position.x + normx * shiftT,
StartTarget.transform.position.y + (EndTarget.transform.position.y - StartTarget.transform.position.y) * perm - gameObject.transform.position.y,
StartTarget.transform.position.z + (EndTarget.transform.position.z - StartTarget.transform.position.z) * perm - gameObject.transform.position.z + normz * shiftT
    );
        transform.Translate(dest.x, dest.y, dest.z);
    }

}
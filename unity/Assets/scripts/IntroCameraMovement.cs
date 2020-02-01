using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// move this from From to To over TotalTime using the Smooth curve
public class IntroCameraMovement : MonoBehaviour
{
    public GameObject From;
    public GameObject To;
    public Camera Camera;

    public float TotalTime = 1;
    public AnimationCurve Smooth;

    // from zero to total time
    float cursor = 0;

    // Update is called once per frame
    void Update()
    {
        cursor += Time.deltaTime;
        if(cursor >= TotalTime)
        {
            cursor = TotalTime;
        }

        var t = cursor / TotalTime;

        this.Camera.transform.position = P(t);
    }

    private static Vector3 Z(Vector3 v)
    {
        return new Vector3(v.x, v.y, v.z) + Vector3.up * -1;
    }

    private Vector3 P(float t)
    {
        var posFrom = this.From.transform.position;
        var posTo = this.To.transform.position;

        return Vector3.Lerp(posFrom, posTo, this.Smooth.Evaluate(t));
    }

    private void OnDrawGizmos()
    {
        if (From == null) return;
        if (To == null) return;
        Gizmos.DrawLine(From.transform.position, To.transform.position);

        for(float t=0.0f; t<1; t+=1/30.0f)
        {
            var p = P(t);
            Gizmos.DrawLine(p, Z(p));
        }
    }
}

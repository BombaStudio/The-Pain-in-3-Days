using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class forceWall : MonoBehaviour
{
    public bool forced,test;
    public float time;
    public Vector3 dir;

    float reqTime;
    void Start()
    {
        reqTime = time;
    }

    void FixedUpdate()
    {
        if (!forced)
        {
            if (time > 0)
            {
                GetComponent<Rigidbody>().AddForce(dir);
                time -= Time.deltaTime;
            }
            else
            {
                dir = -dir;
                time = reqTime;
                forced = !test;
            }
        }
    }
}

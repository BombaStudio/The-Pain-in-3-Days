using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCircle : MonoBehaviour
{
    public float daynighttime;
    public float daynightspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // daynighttime = daynightspeed * Time.deltaTime;
        transform.Rotate(daynighttime * Time.deltaTime, 0, 0);
    }
}

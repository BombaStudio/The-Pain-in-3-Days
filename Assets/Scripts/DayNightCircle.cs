using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCircle : MonoBehaviour
{
    public float daynightspeed;
    public float dayPassed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // daynighttime = daynightspeed * Time.deltaTime;
        transform.Rotate(daynightspeed * Time.deltaTime, 0, 0);
        dayPassed += daynightspeed * Time.deltaTime;
        if (dayPassed >= 360 && dayPassed <= 361)
        {
            Debug.Log("1 Gün Geçti");
        }
        else if (dayPassed >= 720 && dayPassed <= 721)
        {
            Debug.Log("2 Gün Geçti");
        }
        else if (dayPassed >= 1080 && dayPassed <= 1081)
        {
            Debug.Log("3 Gün Geçti");
        }
    }
}

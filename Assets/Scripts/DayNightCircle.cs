using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCircle : MonoBehaviour
{
    public float daynightspeed;
    public float dayPassed;
    public float phoneCallTime;
    public float phoneCallLastTime;

    // Start is called before the first frame update
    void Start()
    {
        phoneCallTime = Random.Range(30, 60);
        phoneCallLastTime = 61;
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

        if (dayPassed >= 30 && dayPassed <= 35)
        {
            Debug.Log("Telefon Çalıyor(troll)");
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Telefon Açıldı");
            }
        }
        else if (dayPassed >= 60 && dayPassed <= 65)
        {
            Debug.Log("Telefon Çalıyor(ihbar)");
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Telefon Açıldı");
            }
        }
        else if (dayPassed >= 120 && dayPassed <= 125)
        {
            Debug.Log("Telefon Çalıyor(troll)");
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Telefon Açıldı");
            }
        }
        else if (dayPassed >= 300 && dayPassed <= 305)
        {
            Debug.Log("Telefon Çalıyor(ihbar)");
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Telefon Açıldı");
            }
        }
        else if (dayPassed >= 350 && dayPassed <= 355)
        {
            Debug.Log("Telefon Çalıyor(troll)");
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Telefon Açıldı");
            }
        }
        else if (dayPassed >= 410 && dayPassed <= 415)
        {
            Debug.Log("Telefon Çalıyor(ihbar)");
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Telefon Açıldı");
            }
        }
    }
}

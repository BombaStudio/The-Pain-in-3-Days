using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCircle : MonoBehaviour
{
    public float daynightspeed;
    public float dayPassed;
    public float phoneCallTime;
    public float phoneCallLastTime;

    public GameController gc;

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
        /*
        if (dayPassed >= 360 && dayPassed <= 361)
        {
            Debug.Log("1 Gün Geçti");
            gc.data.day = 1;
            
        }
        else if (dayPassed >= 720 && dayPassed <= 721)
        {
            Debug.Log("2 Gün Geçti");
            gc.data.day = 2;
        }
        else if (dayPassed >= 1080 && dayPassed <= 1081)
        {
            Debug.Log("3 Gün Geçti");
            gc.data.day = 3;
        }
        */

        #region day 1
        if (!gc.ringing)
        {
            if (dayPassed > 30 && dayPassed < 60)
            {
                Debug.Log("Telefon Çalıyor(troll)");
                gc.ringing = true;
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Debug.Log("Telefon Açıldı");
                }
            }
            else if (dayPassed > 40 && dayPassed < 70)
            {
                Debug.Log("Telefon Çalıyor(ihbar)");
                gc.ringing = true;
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Debug.Log("Telefon Açıldı");
                }
            }
            else if (dayPassed > 90 && dayPassed < 120)
            {
                Debug.Log("Telefon Çalıyor(troll)");
                gc.ringing = true;
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Debug.Log("Telefon Açıldı");
                }
            }
            else if (dayPassed > 100 && dayPassed < 130)
            {
                Debug.Log("Telefon Çalıyor(ihbar)");
                gc.ringing = true;
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Debug.Log("Telefon Açıldı");
                }
            }
        }
        #endregion
    }
}

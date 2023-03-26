using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCircle : MonoBehaviour
{
    public float daynightspeed;
    public float dayPassed;
    public float phoneCallTime;
    public float phoneCallLastTime;

    [SerializeField] GameObject yagmaci,stone1,stone2;

    public GameController gc;

    public int index;


    // Start is called before the first frame update
    void Start()
    {
        phoneCallTime = Random.Range(30, 60);
        phoneCallLastTime = 61;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (gc.GameState == "Game")
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
            if (dayPassed > 90 && dayPassed < 120 && index == 0)
            {
                Debug.Log("Telefon Çalıyor(troll)");
                gc.ringing = true;
                gc.callType = "trol";
                gc.stp = true;
                index++;
            }
            else if (dayPassed > 100 && dayPassed < 130 && index == 1)
            {
                Debug.Log("Telefon Çalıyor(ihbar)");
                gc.ringing = true;
                gc.callType = "ihbar";
                gc.stp = true;
                index++;
            }
            else if (dayPassed > 210 && dayPassed < 240 && index == 2)
            {
                Debug.Log("Telefon Çalıyor(troll)");
                gc.ringing = true;
                gc.callType = "trol";
                gc.stp = true;
                index++;
            }
            else if (dayPassed > 220 && dayPassed < 270 && index == 3)
            {
                Debug.Log("Telefon Çalıyor(ihbar)");
                gc.ringing = true;
                gc.callType = "ihbar";
                gc.stp = true;
                index++;
            }
            #endregion

            #region day 2
            //yardım ekibi
            else if (dayPassed > 330 && index == 4 && gc.yardim > 0)
            {
                if (!stone2.GetComponent<AudioSource>().isPlaying) stone2.GetComponent<AudioSource>().Play();
                for (int i = 0; i < (int)Random.Range(2, 5); i++)
                {
                    //stone1.transform.Translate(i * Time.deltaTime, 0, 0);
                    stone2.transform.Translate(i * Time.deltaTime, 0, -i * Time.deltaTime);
                }
                //stone2.GetComponent<AudioSource>().Stop();
                index++;
            }
            //yağma ekibi
            else if (dayPassed > 420 && index == 5)
            {
                //GameObject a = Instantiate(yagmaci, new Vector3(Random.Range(20, 30), -3.5f, Random.Range(-40, -50)), Quaternion.identity);
                yagmaci.SetActive(true);
                index++;
            }
            else if (dayPassed > 480 && index == 6 && gc.yardim > 1)
            {
                if (!stone2.GetComponent<AudioSource>().isPlaying) stone2.GetComponent<AudioSource>().Play();
                for (int i = 0; i < (int)Random.Range(2, 5); i++)
                {
                    //stone1.transform.Translate(i * Time.deltaTime, 0, 0);
                    stone2.transform.Translate(i * Time.deltaTime, 0, -i * Time.deltaTime);
                }
                index++;
            }
            #endregion

            #region day 3
            //yardım ekibi
            else if (dayPassed > 510 && index == 7)
            {
                if (!stone2.GetComponent<AudioSource>().isPlaying) stone2.GetComponent<AudioSource>().Play();
                for (int i = 0; i < (int)Random.Range(2, 5); i++)
                {
                    //stone1.transform.Translate(i * Time.deltaTime, 0, 0);
                    stone2.transform.Translate(i * Time.deltaTime, 0, -i * Time.deltaTime);
                }
                index++;
            }
            else if (dayPassed > 540 && index == 8)
            {
                gc.data.air -= Time.deltaTime;
            }
            #endregion
        }
    }
}

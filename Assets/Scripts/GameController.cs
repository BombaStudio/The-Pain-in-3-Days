using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameData data;
    public Edvanter edvanter;
    [SerializeField] List<GameObject> rooms;
    [SerializeField] GameObject fog_prefab;
    [SerializeField] AudioClip quake, openPhone,eat,drink,call;

    public string GameState;
    public float scene_cooldown;

    public EdvanterObject usableObject;
    public float objectTime;

    [SerializeField] Text health_print, food_print, water_print, air_print;
    [SerializeField] Button phone_button, health_button, food_button, water_button;

    public bool usePhone,ringing;
    [SerializeField] float minutes;
    public string callType;

    void Start()
    {
        Camera.main.transform.position = new Vector3(-13.75f, 25, -7.25f);
        GameObject myroom = rooms.ToArray()[0];
        foreach (Transform g in myroom.transform.GetComponentInChildren<Transform>())
        {
            GameObject fog_obj = Instantiate(fog_prefab, g.position, Quaternion.identity);
            fog_obj.transform.parent = g;
            fog_obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (data.health > 100) data.health = 100;
        if (data.air > 100) data.air = 100;
        if (data.food > 100) data.food = 100;
        if (data.water > 100) data.water = 100;

        health_print.text = "%" + ((int)data.health).ToString();
        air_print.text = "%" + ((int)data.air).ToString();
        food_print.text = "%" + ((int)data.food).ToString();
        water_print.text = "%" + ((int)data.water).ToString();

        foreach (Transform c in transform.GetChild(0).GetComponentInChildren<Transform>())
        {
            if (c.name == GameState) c.gameObject.SetActive(true);
            else c.gameObject.SetActive(false);
        }
        switch (GameState)
        {
            case "Start": startgame(); break;
            case "Game": game(); break;
            default: break;
        }
    }


    public void game()
    {
        if (ringing)
        {
            if (usePhone) { }
            else
            {
                GetComponent<AudioSource>().clip = call;
                if (!GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
            }
        }
        
        if (usePhone)
        {
            foreach (EdvanterObject eo in edvanter.objects)
            {
                if (eo.id == 0)
                {
                    usableObject = eo;
                    eo.health = (int)(eo.useCooldown / 180 * 100);
                    objectTime = eo.useCooldown;
                    break;
                }
            }
        }
       
        else
        {
            if (usableObject == null || usableObject.id == 0)
            {
                objectTime = 0;
                usableObject = null;
            }
        }
        

        if (objectTime > 0)
        {
            if (usableObject != null)
            {
                objectTime -= Time.deltaTime;
                if (usableObject.id == 0 && usePhone)
                {
                    usableObject.useCooldown = objectTime;
                }
                
                //if (!GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            if (usableObject != null && usableObject.id == 0)
            {
                foreach(EdvanterObject eo in edvanter.objects)
                {
                    if (eo.id == 0)
                    {
                        //eo.useCooldown = objectTime;
                        break;
                    }
                }
                usePhone = false;
            }
            usableObject = null;
        }

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(-7, -2.5f, -11),Time.deltaTime);
        foreach (EdvanterObject eo in edvanter.objects)
        {
            //Debug.Log(btns.ToArray()[eo.id].transform.GetChild(0).GetComponent<Text>().text);
            switch (eo.id)
            {
                case 0:
                    phone_button.transform.GetChild(0).GetComponent<Text>().text = eo.health.ToString();
                    break;
                case 1:
                    food_button.transform.GetChild(0).GetComponent<Text>().text = eo.health.ToString();
                    break;
                case 2:
                    water_button.transform.GetChild(0).GetComponent<Text>().text = eo.health.ToString();
                    break;
                case 3:
                    health_button.transform.GetChild(0).GetComponent<Text>().text = eo.health.ToString();
                    break;
                default: break;
            }
        }
    }
    public void startgame()
    {
        if (Camera.main.transform.position.y < 1)
        {
            GetComponent<AudioSource>().clip = quake;
            if (!GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
            if (scene_cooldown > 0)
            {
                foreach (GameObject room in rooms)
                {
                    foreach (Transform g in room.transform.GetComponentInChildren<Transform>())
                    {
                        if (g.GetComponent<forceWall>() && g.GetComponent<forceWall>().forced)
                        {
                            g.GetComponent<forceWall>().forced = false;
                        }
                    }
                }
                scene_cooldown -= Time.deltaTime;
            }
            else
            {
                GetComponent<AudioSource>().Stop();
                rooms.Remove(rooms.ToArray()[0]);
                foreach (GameObject room in rooms)
                {
                    room.transform.parent = transform.GetChild(0).Find("Game");
                    foreach (Transform g in room.transform.GetComponentInChildren<Transform>())
                    {
                        if (g.GetComponent<forceWall>() && g.GetComponent<forceWall>().test)
                        {
                            if (g.transform.childCount > 0) g.GetChild(0).gameObject.SetActive(false);
                            g.GetComponent<forceWall>().enabled = false;
                            g.GetComponent<Rigidbody>().isKinematic = false;
                        }
                    }

                }
                GameState = "Game";
            }
        }
        else
        {
            Camera.main.transform.Translate(0, -2.5f * Time.deltaTime, 0);
        }
    }
    public void useObject(int id)
    {
        if (usableObject == null || usableObject.id == 0)
        {
            foreach (EdvanterObject eo in edvanter.objects)
            {
                if (eo.id == id)
                {
                    if (eo.id == 0)
                    {
                        GetComponent<AudioSource>().clip = openPhone;
                        GetComponent<AudioSource>().Play();
                        if (usePhone)
                        {
                            if (ringing)
                            {
                                ringing = false;
                            }
                            else
                            {
                                usePhone = false;
                                usableObject = null;
                            }
                        }
                        else
                        {
                            if (eo.useCooldown > 0 && eo.health > 0)
                            {
                                usePhone = true;
                                objectTime = eo.useCooldown;
                                Debug.Log(eo.id);
                                //eo.health -= 1;
                                usableObject = eo;
                            }
                        }
                    }
                    else
                    {
                        if (eo.health != 0)
                        {
                            usePhone = false;
                            objectTime = eo.useCooldown;
                            Debug.Log(eo.id);
                            eo.health -= 1;
                            usableObject = eo;
                            switch (usableObject.id)
                            {
                                case 1:
                                    GetComponent<AudioSource>().clip = eat;
                                    break;
                                case 2:
                                    GetComponent<AudioSource>().clip = drink;
                                    break;
                                default: break;
                            }
                            GetComponent<AudioSource>().Play();
                        }
                        else break;
                        
                    }
                    
                    
                }
            }
        }
    }
}

[System.Serializable]
public class Edvanter
{
    public List<EdvanterObject> objects;
}
[System.Serializable]
public class EdvanterObject
{
    public int id;
    public int health;
    public int effect;
    public float useCooldown;
    //public bool used;
}
[System.Serializable]
public class GameData
{
    public float health = 100;
    public float food = 100;
    public float water = 100;
    public float air = 100;
    public int day = 0;
}
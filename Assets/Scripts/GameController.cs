using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public Edvanter edvanter;
    [SerializeField] List<GameObject> rooms;

    public string GameState;
    public float scene_cooldown;

    [SerializeField] List<Button> btns;

    void Start()
    {
        Camera.main.transform.position = new Vector3(-13.75f,25,-7.25f);
    }

    // Update is called once per frame
    void Update()
    {
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
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(-11, -2, -11),Time.deltaTime);
        foreach (EdvanterObject eo in edvanter.objects)
        {
            //Debug.Log(btns.ToArray()[eo.id].transform.GetChild(0).GetComponent<Text>().text);
            btns.ToArray()[eo.id].transform.GetChild(0).GetComponent<Text>().text = eo.health.ToString();
        }
    }
    public void startgame()
    {
        if (Camera.main.transform.position.y < 1)
        {
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
                rooms.Remove(rooms.ToArray()[0]);
                foreach (GameObject room in rooms)
                {
                    room.transform.parent = transform.GetChild(0).Find("Game");
                    foreach (Transform g in room.transform.GetComponentInChildren<Transform>())
                    {
                        if (g.GetComponent<forceWall>() && g.GetComponent<forceWall>().test)
                        {
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
    //public bool used;
}
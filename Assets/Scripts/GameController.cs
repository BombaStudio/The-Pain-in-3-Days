using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Edvanter edvanter;
    [SerializeField] List<GameObject> rooms;

    public string GameState;
    public float scene_cooldown;

    void Start()
    {
        
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
            case "Start": startgame();break;
            default: break;
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
                            g.GetComponent<forceWall>().test = false;
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
    public float health;
    public float effect;
    //public bool used;
}
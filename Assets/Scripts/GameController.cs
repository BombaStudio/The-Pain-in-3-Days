using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Edvanter edvanter;
    [SerializeField] GameObject room;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startgame();
    }

    public void startgame()
    {
        if (Camera.main.transform.position.y <= 1)
        {
            foreach(Transform g in room.transform.GetComponentInChildren<Transform>())
            {
                if (g.GetComponent<forceWall>() && g.GetComponent<forceWall>().forced)
                {
                    g.GetComponent<forceWall>().forced = false;
                }
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
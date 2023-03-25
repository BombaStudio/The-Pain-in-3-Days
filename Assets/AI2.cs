using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI2 : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float totalspeed;
    public float stoppingDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((player.position - transform.position).normalized * speed * Time.deltaTime);
        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) <= stoppingDistance)
        {
            speed = 0;
        }
        else
        {
            speed = totalspeed;
        }
    }
}

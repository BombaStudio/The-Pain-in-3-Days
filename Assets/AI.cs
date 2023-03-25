using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public bool helpCall;
    public Transform player;
    public float speed;
    public float totalspeed;
    public float stoppingDistance;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (helpCall == true)
        {
            transform.Translate((player.position - transform.position).normalized * speed * Time.deltaTime);
            transform.LookAt(player);

            if (Vector3.Distance(transform.position, player.position) <= stoppingDistance)
            {
                speed = 0;
                anim.SetBool("walk", false);
            }
            else
            {
                speed = totalspeed;
                anim.SetBool("walk", true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class AI : MonoBehaviour
{
    public bool helpCall;
    public Transform player;
    public float speed;
    public float totalspeed;
    public float stoppingDistance;
    public Animator anim;
    public GameController controller;

    public float destroyCooldown = 1;
    public bool destroy;

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
        if (destroy)
        {
            if (destroyCooldown > 0) destroyCooldown -= Time.deltaTime;
            else
            {
                controller.cutArm = true;
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "help")
        {
            destroy = true;
        }
    }
}

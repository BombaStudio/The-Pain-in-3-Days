using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] GameObject hear,leftArm,rightArm;
    [SerializeField] Animator animator;

    public string pose;
    public bool isAgree;

    public GameController gc;

    void Start()
    {
        
    }

    void Update()
    {
        if (gc.objectTime > 0 && gc.usableObject != null)
        {
            switch (gc.usableObject.id)
            {
                case 0:
                    break;
                case 1:
                    gc.data.food += gc.usableObject.effect * Time.deltaTime;
                    break;
                case 2:
                    gc.data.water += gc.usableObject.effect * Time.deltaTime;
                    break;
                case 3:
                    gc.data.health += gc.usableObject.effect * Time.deltaTime;
                    break;
                default:break;
            }
        }
        //leftArm.transform.LookAt(hear.transform.position);
        switch (pose)
        {
            case "call":
                //animator.SetFloat(Animator.StringToHash("movement"), Mathf.Lerp(animator.GetFloat(Animator.StringToHash("call")),1,Time.deltaTime));
                //animator.SetBool(Animator.StringToHash("isAgree"), isAgree);
                break;
            case "look":
                break;
            default: break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] GameObject phoneObj,leftTarget,rightTarget,headObj;
    [SerializeField] Animator animator;

    public string pose;
    public bool isAgree;

    public GameController gc;

    void Start()
    {
        
    }

    void Update()
    {
        if (gc.data.health > 0)
        {
            phoneObj.SetActive(false);

            if (gc.cutArm)
            {


                //gc.cutArm = false;
                if (gc.sansur.color.a < 1)
                {
                    Debug.Log(11);
                    gc.sansur.color = new Color(0, 0, 0, gc.sansur.color.a + Time.deltaTime);
                }
                else
                {
                    GetComponent<AudioSource>().Play();
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);

                    gc.edvanter.objects[0].health = 0;
                    gc.edvanter.objects[0].useCooldown = 0;
                    gc.usableObject = null;

                    gc.data.health -= 50;
                    gc.usePhone = false;
                    gc.ringing = false;
                    gc.cutArm = false;
                }
                Debug.Log(gc.data.health / 50);
            }
            else
            {
                if (gc.sansur.color.a > 0 && gc.data.health > 0) gc.sansur.color = new Color(0, 0, 0, gc.sansur.color.a - Time.deltaTime);
            }

            if (gc.objectTime > 0 && gc.usableObject != null)
            {
                switch (gc.usableObject.id)
                {
                    case 0:
                        if (Input.GetMouseButton(0))
                        {
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hit;

                            // Raycast ile zemine çarpýldýðýnda
                            if (Physics.Raycast(ray, out hit))
                            {
                                // Küpün pozisyonunu týklanan noktaya ayarla
                                Vector3 cubePosition = hit.point + Vector3.up * 0.5f;
                                Debug.Log(cubePosition);
                                cubePosition.z = Mathf.Clamp(cubePosition.z, -12.5f, -13.5f);
                                leftTarget.transform.position = cubePosition;
                            }
                        }
                        phoneObj.SetActive(true);
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
                    default: break;
                }
            }
            if (gc.data.air < 60) gc.data.health -= 30 / gc.data.air * Time.deltaTime;
            if (gc.data.water < 40) gc.data.health -= Mathf.Sin(gc.day.transform.rotation.x * Mathf.Deg2Rad) > 0
                    ? 40 / gc.data.water * Time.deltaTime
                    : 30 / gc.data.water * Time.deltaTime;
            if (gc.data.food < 40) gc.data.health -= Mathf.Sin(gc.day.transform.rotation.x * Mathf.Deg2Rad) < 0
                    ? 40 / gc.data.food * Time.deltaTime
                    : 30 / gc.data.food * Time.deltaTime;

            if (gc.data.air > 1) gc.data.air -= 0.03f * Time.deltaTime;
            if (gc.data.food > 1) gc.data.food -= 0.15f * Time.deltaTime;
            if (gc.data.water > 1) gc.data.water -= 0.2f * Time.deltaTime;
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
        else
        {
            gc.GameState = "GameOver";
        }
    }
}

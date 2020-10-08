using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneezeKey : MonoBehaviour
{
    private float cooldownTime = 2;
    private float nextTime = 0;
    private bool isRolling = false;
    public bool IsRolling
    {
        get { return isRolling; }
        set { isRolling = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
            if (!isRolling)
                if (Input.GetKeyDown(KeyCode.J))
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("Sneeze");
                    GameObject.Find("Sneeze").GetComponent<CapsuleCollider>().enabled = true;
                    GameObject.Find("Sneeze").GetComponent<ParticleSystem>().Play();
                    nextTime = Time.time + cooldownTime;
                }
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
                isRolling = true;
        }
        else if (isRolling)
        {
            isRolling = false;
        }
    }
}

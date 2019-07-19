using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

  
    void Update()
    {
        if(Input.GetKey (KeyCode.LeftArrow))
        {
            anim.SetInteger("State",1);
        }
        {
            if(Input.GetKey (KeyCode.RightArrow))
            {
                anim.SetInteger("State",1);
            }
            {
                if(Input.GetKey (KeyCode.UpArrow))
                {
                    anim.SetInteger("State", 2);
                }
            }
        }

    }
}

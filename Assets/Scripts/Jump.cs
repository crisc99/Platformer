using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
   public AudioSource jump;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        jump.Play();
    }
}

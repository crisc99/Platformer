using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public int speed;
  void OnCollisionEnter(Collision other)
    {
         if (other.gameObject.CompareTag("Player"))
         {
             other.gameObject.GetComponent<Rigidbody2D>
                     ().AddForce(Vector3.up*speed);
         }
     }
 }
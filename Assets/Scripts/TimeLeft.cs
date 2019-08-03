using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLeft : MonoBehaviour
{
         private float timer = 45f;
         private Text timerSeconds;

         void Start ()
         {
             timerSeconds = GetComponent<Text>();
         }

         void Update()
         {
             timer -= Time.deltaTime;
             timerSeconds.text = timer.ToString("f2");
             if(timer <= 0)
             {
                        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene("Scubo2");  ;

             }
         }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {
    
    //Zeit bis die nächste Szene ausgeführt wird
    private float timer= 6;     
 
    void Update()
    {
        //Initialisierung des Timers
        timer -= Time.deltaTime;        
        //Bei Knopfdruck oder Ablauf der Zeit wird Menu Szene geladen
        if(Input.anyKeyDown || timer < 0)   
        {
            SceneManager.LoadScene("Menu");
        }
    }

}

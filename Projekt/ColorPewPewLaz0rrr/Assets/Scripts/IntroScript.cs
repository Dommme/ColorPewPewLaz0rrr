using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {
    
    private float timer= 6;
 
    void Update()
    {
        timer -= Time.deltaTime;
        if(Input.anyKeyDown || timer < 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }

}

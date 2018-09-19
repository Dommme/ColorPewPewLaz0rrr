using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

public void playGame(){                          //playGame() wird ausgeführt bei Klick auf "1P" Button
    
    SceneManager.LoadScene("GameScene");        //Spiel Szene wird geladen  
    
    
}
    public void quitGame(){                     //quitGame() wird bei Klick auf Quit ausgeführt und beendet das Spiel
    Debug.Log("Quit Game");
    Application.Quit();
    
    
}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UIscript : MonoBehaviour {

    

public RawImage[] UIColors;
public RawImage[] UILifes;

    public TMP_Text ScoreProText;

 
    private int countScore = 0;         //Anfangsscore bei Beginn des Spiels
    public int countLife = 3;           //Anzahl an Leben. Hier an GUI angepasst
	void Start () {
        countScore=0;
        
            //Anfangszustand GUI
        UILifes[0].enabled=false;       //GUI bei GameOver
        UILifes[1].enabled=false;       //GUI bei einem verbleibendem Leben
        UILifes[2].enabled=false;       //GUI bei zwei verbleibenden Leben
        UILifes[3].enabled=true;        //GUI bei drei verbleibenden Leben, also bei Beginn des Spiels   
        UIColors[0].enabled=false;       //Keine Farbe des Lasers ausgewählt, Normalzustand bei Beginn des Spiels
        UIColors[1].enabled=false;      //Blauer Laser ausgewählt
        UIColors[2].enabled=false;      //Gelber Laser ausgewählt
        UIColors[3].enabled=true;      //Roter Laser ausgewählt
        
        
	}
	   //GUI Änderung bei Auswahl des roten Lasers
   public void SelectRed(){
        UIColors[0].enabled=false;
        UIColors[1].enabled=false; 
        UIColors[2].enabled=false;
        UIColors[3].enabled=true;
       }
        //GUI Änderung bei Auswahl des blauen Lasers
    public void SelectBlue(){
        UIColors[0].enabled=false;
        UIColors[1].enabled=true; 
        UIColors[2].enabled=false;
        UIColors[3].enabled=false;
    }
        //GUI Änderung bei Auswahl des gelben Lasers
     public void SelectYellow(){
        UIColors[0].enabled=false;
        UIColors[1].enabled=false; 
        UIColors[2].enabled=true;
        UIColors[3].enabled=false;
    }
        //GUI Änderung bei Auswahl keines Lasers
    public void SelectNone(){
        UIColors[0].enabled=true;
        UIColors[1].enabled=false; 
        UIColors[2].enabled=false;
        UIColors[3].enabled=false;
       }
        //GUI Änderung bei verlieren von Leben
	 public void Life(int value){
        countLife += value;                    //Leben wird angepasst.
        
        //GUI Änderung bei verbleibenden 2 Leben
        if(countLife==2){
            UILifes[0].enabled=false;
            UILifes[1].enabled=false;
            UILifes[2].enabled=true;
            UILifes[3].enabled=false;    
        }
         //GUI Änderung bei verbleibendem Leben
        if(countLife==1){
            UILifes[0].enabled=false;
            UILifes[1].enabled=true;
            UILifes[2].enabled=false;
            UILifes[3].enabled=false;    
        }
         //GUI Änderung bei keinem Leben (Game Over)
         if(countLife==0){
            UILifes[0].enabled=true;
            UILifes[1].enabled=false;
            UILifes[2].enabled=false;
            UILifes[3].enabled=false; 
            Debug.Log("GameOver!");
        }
    
        
    }
        //Getter für countLife Variable
    public int getLife(){
        return countLife;
        
    }
        // Update is called once per frame
	void Update () {
	}
        //Score Erhöhung wird pro frame ausgeführt und in GameState Handler überführt
    public void Score(int value){
        countScore += value;
        ScoreProText.text= countScore.ToString();
        
    }
}
   


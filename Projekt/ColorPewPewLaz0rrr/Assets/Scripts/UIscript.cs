using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UIscript : MonoBehaviour {

    

public RawImage[] UIColors;
public RawImage[] UILifes;

    public Text ScoreText;
 
    private int countScore = 0;
    public int countLife = 3;
	void Start () {
        
        
        UILifes[0].enabled=false; //0Life
        UILifes[1].enabled=false; //1Life
        UILifes[2].enabled=false; //2Life 
        UILifes[3].enabled=true;  //3Life 
        
        UIColors[0].enabled=true;  //Non
        UIColors[1].enabled=false; //Blue
        UIColors[2].enabled=false; //Yellow
        UIColors[3].enabled=false; //Red
	}
	
   public void SelectRed(){
        UIColors[0].enabled=false;
        UIColors[1].enabled=false; 
        UIColors[2].enabled=false;
        UIColors[3].enabled=true;
       }
    public void SelectBlue(){
        UIColors[0].enabled=false;
        UIColors[1].enabled=true; 
        UIColors[2].enabled=false;
        UIColors[3].enabled=false;
    }
     public void SelectYellow(){
        UIColors[0].enabled=false;
        UIColors[1].enabled=false; 
        UIColors[2].enabled=true;
        UIColors[3].enabled=false;
    }
    public void SelectNone(){
        UIColors[0].enabled=true;
        UIColors[1].enabled=false; 
        UIColors[2].enabled=false;
        UIColors[3].enabled=false;
       }
	 public void Life(){
        countLife--;
        
        if(countLife==2){
            UILifes[0].enabled=false;
            UILifes[1].enabled=false;
            UILifes[2].enabled=true;
            UILifes[3].enabled=false;    
        }
        if(countLife==1){
            UILifes[0].enabled=false;
            UILifes[1].enabled=true;
            UILifes[2].enabled=false;
            UILifes[3].enabled=false;    
        }
         if(countLife==0){
            UILifes[0].enabled=true;
            UILifes[1].enabled=false;
            UILifes[2].enabled=false;
            UILifes[3].enabled=false; 
            Debug.Log("GameOver!");
            //SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    
        
    }
    // Update is called once per frame
	void Update () {
	}

    public void Score(int value){
        ScoreText.text= countScore.ToString();
        countScore += value;
        
    }
}
   


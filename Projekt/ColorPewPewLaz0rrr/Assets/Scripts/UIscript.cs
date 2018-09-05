using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIscript : MonoBehaviour {

    

public RawImage[] UIColors;
    public Text ScoreText;
    public Text LifeText;
 
    private int countScore = 0;
    public int countLife = 100;
	void Start () {

        UIColors[0].enabled=true;  //White
        UIColors[1].enabled=false; //Red
        UIColors[2].enabled=false; //Green
        UIColors[3].enabled=false; //Blue
        UIColors[4].enabled=false; //Yellow
	}
	
   public void SelectRed(){
        UIColors[0].enabled=false;
        UIColors[1].enabled=true; 
        UIColors[2].enabled=false;
        UIColors[3].enabled=false;
        UIColors[4].enabled=false;
       }
    public void SelectBlue(){
        UIColors[0].enabled=false;
        UIColors[1].enabled=false; 
        UIColors[2].enabled=false;
        UIColors[3].enabled=true;
        UIColors[4].enabled=false;
    }
     public void SelectYellow(){
        UIColors[0].enabled=false;
        UIColors[1].enabled=false; 
        UIColors[2].enabled=false;
        UIColors[3].enabled=false;
        UIColors[4].enabled=true;
    }
	
    // Update is called once per frame
	void Update () {
	}

    public void Score(){
        ScoreText.text= countScore.ToString();
        countScore++;
        
    }

    public void Life(){
        LifeText.text= countLife.ToString();
        countLife--;
        Debug.Log(countLife + "Leben übrig");
        if(countLife==0){
            Debug.Log("GameOver!");
            //SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            
            
        }
        
    }
}

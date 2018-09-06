using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    float timer = 0;
    public bool AxisL = false;
    public bool AxisR = false;
    public bool AxisU = false;
    public bool AxisD = false;

    public float moveSmoothVar = 3.0f;
    public Vector3 playerPos;

    public bool cooledDown = false;

    public GameObject shuttlePrefab;
    public GameObject shuttle;

    public GameObject blueProjectile;
    public GameObject redProjectile;
    public GameObject yellowProjectile;

    string color = "red";
                                                                                    // Use this for initialization
    void Start()
    {
        /*
        shuttle = GameObject.CreatePrimitive(PrimitiveType.Cube);
        shuttle.GetComponent<Renderer>().material.color = new Color(0.3f, 0.7f, 0.1f);
        shuttle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        */
        shuttle = Instantiate(shuttlePrefab);

        shuttle.transform.Rotate(new Vector3(0, 180, 0));                           // Drehe den Spieler in die richtige Richtung

    }

                                                                                    // Update is called once per frame
    void Update()
    {

                                                                                    // Timer für diverse Zeitversetzte Aktionen
                                                                                    ///////////////////////////////////////////
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {

            FindObjectOfType<UIscript>().Score();                                   // Score aktualisieren
            cooledDown = true;                                                      // Projektil wieder feuerbar machen
            timer = 0;                                                              // Timer resetten
        }

        checkKey();                                                                 // Buttons Prüfen

        checkAxis();                                                                // Analog-Stick Prüfen

        playerPos = shuttle.transform.position;                                     // PlayPos Aktualisieren für Übergabe an Kamera


    }


    void checkAxis()
    {

                                                                                    // Variablen auf false / true setzen, 
                                                                                    // um eventuell Position zu resetten (siehe movePlayer()).
                                                                                    //////////////////////////////////////////////////////////
        AxisR = (Input.GetAxis("Horizontal") > 0.3) ? true : false;
        AxisL = (Input.GetAxis("Horizontal") < -0.3) ? true : false;
        AxisU = (Input.GetAxis("Vertical") > 0.3) ? true : false;
        AxisD = (Input.GetAxis("Vertical") < -0.3) ? true : false;


                                                                                    // Funktion abhängig von AxisInput aufrufen
                                                                                    ///////////////////////////////////////////
                                                                                    
        if (!(AxisR || AxisL || AxisU || AxisD))                                    //// Zentrieren
        {
            if (shuttle.transform.position != Vector3.zero)
            {
                movePlayer("center");
            }


                                                                                    // Alle 8 Richtungen
                                                                                    ////////////////////
        }
        else if (AxisU && AxisR)
        {
            movePlayer("UR");
        }
        else if (AxisU && AxisL)
        {
            movePlayer("UL");
        }
        else if (AxisD && AxisR)
        {
            movePlayer("DR");
        }
        else if (AxisD && AxisL)
        {
            movePlayer("DL");
        }
        else if (AxisU)
        {
            movePlayer("U");
        }
        else if (AxisD)
        {
            movePlayer("D");
        }
        else if (AxisR)
        {
            movePlayer("R");
        }
        else if (AxisL)
        {
            movePlayer("L");
        }



    }

    void checkKey()
    {

                                                                                    // Buttons (sowohl Tastatur als auch GamePad
                                                                                    ////////////////////////////////////////////
        if (Input.GetButton("GreenButton") && cooledDown == true)
        {
            Debug.Log("Fire " + color + "!");                                       // fire!-Button
            fire(); 
        }

                                                                                    // Die Farbauswahl wird entsprechend geändert, 
                                                                                    // damit die Methode ladeLazor() weiß, welches Prefab instanziert werden muss.
                                                                                    //////////////////////////////////////////////////////////////////////////////
        if (Input.GetButton("RedButton"))
        {
            color = "red";
            Debug.Log("Red");
            FindObjectOfType<UIscript>().SelectRed();
        }

        if (Input.GetButton("BlueButton"))
        {
            color = "blue";
            Debug.Log("Blue");
            FindObjectOfType<UIscript>().SelectBlue();
        }

        if (Input.GetButton("YellowButton"))
        {
            color = "yellow";
            Debug.Log("Yellow");
            FindObjectOfType<UIscript>().SelectYellow();
        }

    }

    void movePlayer(string dir)
    {

                                                                                    // (smoothe) Bewegung des Players
                                                                                    // entsprechend des Methodenaufrufs
                                                                                    // U = Up, D = Down usw.
                                                                                    ///////////////////////////////////
        switch (dir)
        {
            case "U":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position,
                    Vector3.up, Time.deltaTime * moveSmoothVar); 
                break;

            case "D":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, 
                    Vector3.down, Time.deltaTime * moveSmoothVar);
                break;

            case "L":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, 
                    Vector3.right, Time.deltaTime * moveSmoothVar); 
                break;

            case "R":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, 
                    Vector3.left, Time.deltaTime * moveSmoothVar);
                break;

            case "UL":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, 
                    Vector3.up + Vector3.right, Time.deltaTime * moveSmoothVar);
                break;

            case "UR":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, 
                    Vector3.up + Vector3.left, Time.deltaTime * moveSmoothVar);
                break;

            case "DL":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, 
                    Vector3.down + Vector3.right, Time.deltaTime * moveSmoothVar);
                break;

            case "DR":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, 
                    Vector3.down + Vector3.left, Time.deltaTime * moveSmoothVar);
                break;

            case "center":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, 
                    Vector3.zero, Time.deltaTime * moveSmoothVar);                  // Zentrierung des players bei nullposition des Analogsticks

                break;

            default:
                break;
        }

    }

                                                                                    // Diese Methode instanziert das Projektil und gibt es zurück, 
                                                                                    // damit es abgefeuert werden kann.
    private GameObject ladeLazor()
    {

        GameObject projectile;

                                                                                    // lange If-Anweisung durch SwitchCase ersetzt. gez: Dome
                                                                                    /////////////////////////////////////////////////////////
        switch (color)
        {
            case "red":
                projectile = Instantiate(redProjectile) as GameObject;
                return projectile;

            case "blue":
                projectile = Instantiate(blueProjectile) as GameObject;
                return projectile;

            case "yellow":
                projectile = Instantiate(yellowProjectile) as GameObject;
                return projectile;

            default:
                return null;
        }
    }

                                                                                    // feuert erzeugtes Projektil
                                                                                    ////////////////////////////
    private void fire() {
        
        GameObject lazor = ladeLazor();                                             // Instanziere das ausgewählte Projektil

        lazor.transform.position = shuttle.transform.position                       // platziere das Projektil direkt vor dem Spieler
            + shuttle.transform.forward;

        Rigidbody pphysics = lazor.GetComponent<Rigidbody>();                       // Danach wird eine Geschwindigkeit und Richtung zugewiesen. 
        pphysics.velocity = shuttle.transform.forward                               // Die Geschwindigkeit findet sich im Skript "ProjectileHandler" und lässt
            * lazor.GetComponent<ProjectileHandler>().velocityFactor;               // sich auch über das Unity Interface direkt steuern. Die Variable heißt "velocityFactor"

        cooledDown = false;
    }
}
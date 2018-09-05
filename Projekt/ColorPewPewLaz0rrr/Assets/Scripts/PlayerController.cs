using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    float timer = 0;
    public bool AxisL = false;
    public bool AxisR = false;
    public bool AxisU = false;
    public bool AxisD = false;

    public float moveSmoothVar = 3.0f;
    public Vector3 playerPos;

    public GameObject shuttle;

    public GameObject blueProjectile;
    public GameObject redProjectile;
    public GameObject yellowProjectile;

    string color = "red";
    // Use this for initialization
    void Start() {

        shuttle = GameObject.CreatePrimitive(PrimitiveType.Cube);
        shuttle.GetComponent<Renderer>().material.color = new Color(0.3f, 0.7f, 0.1f);
        shuttle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //Drehe den Spieler in die richtige Richtung
        shuttle.transform.Rotate(new Vector3(0, 180, 0));
        //Instantiate(shuttle);
    }

    // Update is called once per frame
    void Update() {


        timer += Time.deltaTime;
        if (timer > 1.0f) {

            FindObjectOfType<UIscript>().Score();
            timer = 0;
        }

        // Buttons Prüfen
        checkKey();

        // Analog-Stick Prüfen
        checkAxis();

        // PlayPos Aktualisieren für Übergabe an Kamera
        playerPos = shuttle.transform.position;


    }


    void checkAxis() {

        // Variablen auf false / true setzen, um eventuell Position zu resetten (siehe movePlayer() )


        AxisR = (Input.GetAxis("Horizontal") > 0.3) ? true : false;
        AxisL = (Input.GetAxis("Horizontal") < -0.3) ? true : false;
        AxisU = (Input.GetAxis("Vertical") > 0.3) ? true : false;
        AxisD = (Input.GetAxis("Vertical") < -0.3) ? true : false;


        // funktion abhängig von AxisInput aufrufen
        //// Zentrieren
        if (!(AxisR || AxisL || AxisU || AxisD)) {
            if (shuttle.transform.position != Vector3.zero) {
                movePlayer("center");
            }


        //// Alle 8 Richtungen
        } else if (AxisU && AxisR) {
            movePlayer("UR");
        } else if (AxisU && AxisL) {
            movePlayer("UL");
        } else if (AxisD && AxisR) {
            movePlayer("DR");
        } else if (AxisD && AxisL) {
            movePlayer("DL");
        } else if (AxisU) {
            movePlayer("U");
        } else if (AxisD) {
            movePlayer("D");
        } else if (AxisR) {
            movePlayer("R");
        } else if (AxisL) {
            movePlayer("L");
        }



    }

    void checkKey() {
        


        // Buttons (sowohl Tastatur als auch GamePad

        if (Input.GetButton("GreenButton"))
        {
            Debug.Log("Fire " +color+"!"); // shoot-Button

            //Instanziere das ausgewählte Projektil
            GameObject lazor = ladeLazor();
            //platziere das Projektil direkt vor dem Spieler
            lazor.transform.position = shuttle.transform.position + shuttle.transform.forward;

            //Danach wird eine Geschwindigkeit und Richtung zugewiesen. Die Geschwindigkeit findet sich im Skript "ProjectileHandler" und lässt
            //sich auch über das Unity Interface direkt steuern. Die Variable heißt "velocityFactor"
            Rigidbody pphysics = lazor.GetComponent<Rigidbody>();
            pphysics.velocity = shuttle.transform.forward * lazor.GetComponent<ProjectileHandler>().velocityFactor;
        }

        if (Input.GetButton("RedButton"))
        {
            //Die Farbauswahl wird auf "red" geändert, damit das die Methode ladeLazor() weiß, welches prefab instanziert werden muss
            color = "red";
            Debug.Log("Red");
            FindObjectOfType<UIscript>().SelectRed();
        }

        if (Input.GetButton("BlueButton"))
        {
            //Die Farbauswahl wird auf "blue" geändert, damit das die Methode ladeLazor() weiß, welches prefab instanziert werden muss
            color = "blue";
            Debug.Log("Blue");
            FindObjectOfType<UIscript>().SelectBlue();
        }

        if (Input.GetButton("YellowButton"))
        {
            //Die Farbauswahl wird auf "yellow" geändert, damit das die Methode ladeLazor() weiß, welches prefab instanziert werden muss
            color = "yellow";
            Debug.Log("Yellow");
            FindObjectOfType<UIscript>().SelectYellow();
        }

    }

    void movePlayer(string dir) {

        // smoothe Bewegung des Players

        switch (dir) {
            case "U":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, Vector3.up, Time.deltaTime * moveSmoothVar); // u = up = hoch
                print("oben");
                break;

            case "D": 
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, Vector3.down, Time.deltaTime * moveSmoothVar); // d = down = du weißt schon und so weiter
                print("unten");
                break;

            case "L":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, Vector3.right, Time.deltaTime * moveSmoothVar); // blabla
                print("links");
                break;

            case "R":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, Vector3.left, Time.deltaTime * moveSmoothVar); // blubbblubb
                print("rechts");
                break;

            case "UL":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, Vector3.up + Vector3.right, Time.deltaTime * moveSmoothVar); // <-- keine Ahnung warum Vector3.right statt .left
                print("obenlinks");
                break;

            case "UR":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, Vector3.up + Vector3.left, Time.deltaTime * moveSmoothVar); // <-- keine Ahnung warum Vector3.left statt .right
                print("obenrechts");
                break;

            case "DL":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, Vector3.down + Vector3.right, Time.deltaTime * moveSmoothVar); // <-- keine Ahnung warum Vector3.right statt .left
                print("untenlinks");
                break;

            case "DR":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, Vector3.down + Vector3.left, Time.deltaTime * moveSmoothVar); // <-- keine Ahnung warum Vector3.left statt .right
                print("untenrechts");
                break;

            case "center":
                shuttle.transform.position = Vector3.Lerp(shuttle.transform.position, Vector3.zero, Time.deltaTime * moveSmoothVar); // Zentrierung des players bei nullposition des Analogsticks
                //print("zentrieren!");
                break;

            default:
                break;
        }

    }

    //Diese Methode instanziert das Projektil und gibt es zurück, damit es abgefeuert werden kann. Dadurch wird redundanter Code eingespart.
    private GameObject ladeLazor ()
    {
        GameObject projectile;

        if (color == "red")
        {
            projectile = Instantiate(redProjectile) as GameObject;
            return projectile;
        }

        if (color == "blue")
        {
            projectile = Instantiate(blueProjectile) as GameObject;
            return projectile;
        }

        if (color == "yellow")
        {
            projectile = Instantiate(yellowProjectile) as GameObject;
            return projectile;
        }
        else
        {
            return null;
        }
    }
}

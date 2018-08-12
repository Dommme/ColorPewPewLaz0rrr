using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float timer = 0;
    public bool AxisL = false;
    public bool AxisR = false;
    public bool AxisU = false;
    public bool AxisD = false;

    public float moveSmoothVar = 3.0f;
    public Vector3 playerPos;

    public GameObject shuttle;

    // Use this for initialization
    void Start() {

        shuttle = GameObject.CreatePrimitive(PrimitiveType.Cube);
        shuttle.GetComponent<Renderer>().material.color = new Color(0.3f, 0.7f, 0.1f);
        shuttle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        //Instantiate(shuttle);

    }

    // Update is called once per frame
    void Update() {


        timer += Time.deltaTime;
        if (timer > 1.0f) {


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

        // Gamepad Buttons

        if (Input.GetKeyDown("joystick button 0")) {
            // code hierher
            Debug.Log("Fire!"); // grüner button
        }

        if (Input.GetKeyDown("joystick button 1")) {
            // code hierher
            Debug.Log("Red");
        }

        if (Input.GetKeyDown("joystick button 2")) {
            // code hierher
            Debug.Log("Blue");
        }

        if (Input.GetKeyDown("joystick button 3")) {
            // code hierher
            Debug.Log("Yellow");
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
                print("zentrieren!");
                break;

            default:
                break;
        }

    }

}

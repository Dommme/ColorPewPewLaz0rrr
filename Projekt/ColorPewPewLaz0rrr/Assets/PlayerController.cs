using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float timer = 0;
    bool AxisL = false;
    bool AxisR = false;
    bool AxisU = false;
    bool AxisD = false;

    public GameObject cube;

    // Use this for initialization
    void Start() {

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<Renderer>().material.color = new Color(0.3f, 0.7f, 0.1f);

    }

    // Update is called once per frame
    void Update() {


        timer += Time.deltaTime;
        if (timer > 1.0f) {


            timer = 0;
        }

        checkKey();
        /*
        AxisR = false;
        AxisL = false;
        AxisU = false; 
        AxisD = false;
        */
        checkAxis();


    }

    void checkAxis() {

        // Variablen auf false setzen, um Position zu resetten (siehe movePlayer() )

        AxisR = (Input.GetAxis("Horizontal") > 0.3) ? true : false;
        AxisL = (Input.GetAxis("Horizontal") < -0.3) ? true : false;
        AxisU = (Input.GetAxis("Vertical") > 0.3) ? true : false;
        AxisD = (Input.GetAxis("Vertical") < -0.3) ? true : false;



        // funktion abhängig von AxisInput aufrufen

        if (!(AxisR || AxisL || AxisU || AxisD)) {
            if (cube.transform.position != Vector3.zero) {
                movePlayer("center");
            }
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
                cube.transform.position = Vector3.Lerp(cube.transform.position, Vector3.up, Time.deltaTime * 10.0f); // u = up = hoch
                print("oben");
                break;

            case "D":
                cube.transform.position = Vector3.Lerp(cube.transform.position, Vector3.down, Time.deltaTime * 10.0f); // d = down = du weißt schon und so weiter
                print("unten");
                break;

            case "L":
                cube.transform.position = Vector3.Lerp(cube.transform.position, Vector3.right, Time.deltaTime * 10.0f); // blabla
                print("links");
                break;

            case "R":
                cube.transform.position = Vector3.Lerp(cube.transform.position, Vector3.left, Time.deltaTime * 10.0f); // blubbblubb
                print("rechts");
                break;

            case "UL":
                cube.transform.position = Vector3.Lerp(cube.transform.position, Vector3.up + Vector3.right, Time.deltaTime * 10.0f); // <-- keine Ahnung warum Vector3.right statt .left
                print("obenlinks");
                break;

            case "UR":
                cube.transform.position = Vector3.Lerp(cube.transform.position, Vector3.up + Vector3.left, Time.deltaTime * 10.0f); // <-- keine Ahnung warum Vector3.left statt .right
                print("obenrechts");
                break;

            case "DL":
                cube.transform.position = Vector3.Lerp(cube.transform.position, Vector3.down + Vector3.right, Time.deltaTime * 10.0f); // <-- keine Ahnung warum Vector3.right statt .left
                print("untenlinks");
                break;

            case "DR":
                cube.transform.position = Vector3.Lerp(cube.transform.position, Vector3.down + Vector3.left, Time.deltaTime * 10.0f); // <-- keine Ahnung warum Vector3.left statt .right
                print("untenrechts");
                break;

            case "center":
                cube.transform.position = Vector3.Lerp(cube.transform.position, Vector3.zero, Time.deltaTime * 10.0f); // zentrierung des players bei nullposition des Analogsticks
                print("zentrieren!");
                break;

            default:
                break;
        }

    }

}

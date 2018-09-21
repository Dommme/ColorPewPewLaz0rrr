using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandling : MonoBehaviour
{

    // Kollisionshandling für den Spieler
    private void OnTriggerEnter(Collider other) {
        // Zunächst wird überprüft, ob der Spieler mit einem Meteor kollidiert
        if (other.gameObject.name.Contains("Meteor"))
        {
            //Wenn ja, dann erleidet er schaden
            FindObjectOfType<UIscript>().Life(-1);
        }
        //Ansonsten wird überprüft mit was er genau kollidiert
        else
        {
            switch (other.gameObject.name)
            {
                //Im Falle eines Health Power-Ups bekommt er ein Leben zurück.
                case "HealthPowerUp(Clone)":
                    FindObjectOfType<UIscript>().Life(+1);
                    break;

                //Im Falle eines Invincibility Power-Ups nimmt er für gewisse Zeit keinen Schaden
                case "InvincibilityPowerUp(Clone)":
                    //invincibility
                    break;
                default:
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandling : MonoBehaviour
{
    //Diese Variable gibt in Sekunden an, wie lange das Unbesiegbarkeits Power-Up hält. Hier ändern
    public float unbesiegbarGrenze = 5f;

    // Kollisionshandling für den Spieler
    private void OnTriggerEnter(Collider other) {
        // Zunächst wird überprüft, ob der Spieler mit einem Meteor kollidiert
        if (other.gameObject.name.Contains("Meteor"))
        {
            //Wenn ja, dann erleidet er schaden
            if (FindObjectOfType<PlayerController>().unbesiegbar)
            {
                Destroy(other.gameObject);
            }
            else
            {
                FindObjectOfType<UIscript>().Life(-1);
                Destroy(other.gameObject);
            }
        }
        //Ansonsten wird überprüft mit was er genau kollidiert
        else
        {
            switch (other.gameObject.name)
            {
                //Im Falle eines Health Power-Ups bekommt er ein Leben zurück.
                case "HealthPowerUp(Clone)":
                        FindObjectOfType<UIscript>().Life(1);
                        Destroy(other.gameObject);
                    break;

                //Im Falle eines Invincibility Power-Ups nimmt er für gewisse Zeit keinen Schaden
                case "InvincibilityPowerUp(Clone)":
                    FindObjectOfType<PlayerController>().unbesiegbar = true;
                    Destroy(other.gameObject);
                    break;

                default:
                    break;
            }
        }
    }
}

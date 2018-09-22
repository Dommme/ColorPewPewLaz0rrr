using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandling : MonoBehaviour
{
    public ParticleSystem deathPS;
    public ParticleSystem damagePS;

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
                Instantiate(damagePS, transform.position, transform.rotation);
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
                    other.gameObject.GetComponent<PowerUpController>().playSoundAndDestroy();
                    break;

                //Im Falle eines Invincibility Power-Ups nimmt er für gewisse Zeit keinen Schaden
                case "InvincibilityPowerUp(Clone)":
                    FindObjectOfType<PlayerController>().unbesiegbar = true;
                    FindObjectOfType<PlayerController>().shield.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    other.gameObject.GetComponent<PowerUpController>().playSoundAndDestroy();
                    break;

                default:
                    break;
            }
        }
    }

    // zerstört sich selbst
    public void selfDestruct()
    {
        //macht das Objekt unsichtbar
        GetComponent<MeshRenderer>().enabled = false;

        //Instantiiert Explosion-PS
        Instantiate(deathPS, transform.position, transform.rotation);

    }
}

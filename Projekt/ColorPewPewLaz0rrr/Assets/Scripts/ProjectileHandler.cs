using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour {

    public ParticleSystem meteorExplosion;
    public string color;
    //diese Variable ändern, wenn das Projektil ein andere Geschwindigkeit besitzen soll
    public int velocityFactor = 40;

    private void OnTriggerEnter(Collider other)
    {
        //Prüfe ob der MeteorSpawner getroffen wurde
        if(other.gameObject.name == "MeteorSpawner")
        {
            //wenn ja, dann zerstöre das Projektil, damit es nicht unendlich lange rumfliegt
            Destroy(gameObject);
        }
        //Wenn etwas anderes getroffen wurde
        else
        {
            //überprüfe die Farbstrings der beiden kollidierenden Objekten und zerstöre sie wenn sie stimmen
            if (other.GetComponent<MeteorController>().color == gameObject.GetComponent<ProjectileHandler>().color)
            {
                //Fürs Auge
                Instantiate(meteorExplosion, transform.position, transform.rotation);
                //Die wirkliche Zerstörung
                Destroy(other.gameObject);
                Destroy(gameObject);

                //Der Spieler erhält für das Zerstören eines Meteors 50 Punkte
                FindObjectOfType<UIscript>().Score(50);
            }
            //ansonsten zerstöre nur das Projektil
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

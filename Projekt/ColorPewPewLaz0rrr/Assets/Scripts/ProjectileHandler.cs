using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour {

    public string color;
    //diese Variable ändern, wenn das Projektil die Geschwindigkeit ändern soll
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
                Destroy(other.gameObject);
                Destroy(gameObject);
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

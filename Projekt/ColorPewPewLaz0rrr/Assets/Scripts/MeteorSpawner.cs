using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteor;
    //public GameObject asteroid; // von Dome
    public Vector3 spawnValues;
    public float spawnDelay;
    public float startDelay;
    public bool useGrid = true;
    //public int asteroidenDichte = 15; // von Dome

    void Start()
    {
        StartCoroutine(SpawnMeteors());
    }

    IEnumerator SpawnMeteors()
    {
        //Countdown bis Beginn der Spawnphase
        yield return new WaitForSeconds(startDelay);

        //Spawnphase
        // TODO: Loop condition hinzufügen!
        while (true) {
            //Spawnbereich
            Vector3 spawnPosition;
            Vector3 asteroidPos;
            if (useGrid)
            { //benutze Gridpositionen für Meteoren
                spawnPosition = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), spawnValues.z);
            }
            else
            { //komplett zufällige Positionen für Meteoren
                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
            }
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(meteor, spawnPosition, spawnRotation);
            
            
            
            
            /*
            /// AB HIER DOME ///
            // Umgebungs Asteroide spawnen
            for (int i = 0; i < asteroidenDichte; i++)
            {
                asteroidPos = new Vector3(Random.Range(-spawnValues.x * 4, spawnValues.x * 4), Random.Range(-spawnValues.y * 4, spawnValues.y * 4), spawnValues.z);
                Instantiate(asteroid, asteroidPos, spawnRotation);
            }
            /// BIS HIER DOME ///
            */

            //Wartezeit zwischen Spawns
            yield return new WaitForSeconds(spawnDelay);
        }
    }


}

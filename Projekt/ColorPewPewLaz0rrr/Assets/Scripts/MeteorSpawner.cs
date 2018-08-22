using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorBlue;
    public GameObject meteorRed;
    public GameObject meteorYellow;
    public Vector3 spawnValues;
    public float spawnDelay;
    public float startDelay;
    public bool useGrid = true;

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
            if (useGrid)
            { //benutze Gridpositionen für Meteoren
                spawnPosition = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), spawnValues.z);
            }
            else
            { //komplett zufällige Positionen für Meteoren
                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
            }
            Quaternion spawnRotation = Quaternion.identity;

            switch (Random.Range(0, 3))
            {
                case 0: Instantiate(meteorBlue, spawnPosition, spawnRotation);
                    break;
                case 1: Instantiate(meteorRed, spawnPosition, spawnRotation);
                    break;
                case 2: Instantiate(meteorYellow, spawnPosition, spawnRotation);
                    break;
            }
            //Instantiate(meteorRed, spawnPosition, spawnRotation);

            //Wartezeit zwischen Spawns
            yield return new WaitForSeconds(spawnDelay);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteor;
    public Vector3 spawnValues;
    public float spawnDelay;
    public float startDelay;

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
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(meteor, spawnPosition, spawnRotation);
            //Wartezeit zwischen Spawns
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}

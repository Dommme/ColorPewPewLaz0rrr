using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;
    public Vector3 spawnValues;
    public float spawnDelay = 1;
    public int asteroidenDichte = 25;
    public float asteroidSpeed = 10;

    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        //Countdown bis Beginn der Spawnphase
        yield return new WaitForSeconds(0);

        //Spawnphase
        // TODO: Loop condition hinzufügen!
        while (true)
        {
            //Spawnbereich
            Vector3 asteroidPos;

            Quaternion spawnRotation = Quaternion.identity;


            /// AB HIER DOME ///
            // Umgebungs Asteroide spawnen
            for (int i = 0; i < asteroidenDichte; i++)
            {   
                asteroidPos = new Vector3(Random.Range(-spawnValues.x * 6, spawnValues.x * 6), Random.Range(-spawnValues.y * 4, spawnValues.y * 4), spawnValues.z);

                if((System.Math.Abs(asteroidPos.x) + System.Math.Abs(asteroidPos.y)) < 2)
                {
                    i--;
                    continue;
                }

                Instantiate(asteroid, asteroidPos, spawnRotation);
            }
            /// BIS HIER DOME ///

            //Wartezeit zwischen Spawns
            yield return new WaitForSeconds(spawnDelay);
        }
    }


}

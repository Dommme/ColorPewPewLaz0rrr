using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawnt in regelmäßigen Abständen (spawnDelay) Meteore an einer von 9 verschiedenen Positionen

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorBlue;
    public GameObject meteorRed;
    public GameObject meteorYellow;
    //Power-Ups
    public GameObject powerUp1;
    public GameObject powerUp2;

    public Vector3 spawnValues;
    public float spawnDelay = 1;
    public float startDelay;
    public bool useGrid = true;
    public float meteorSpeed = 10;
    public int powerUpChance;

    void Start()
    {
        StartCoroutine(SpawnMeteors());
    }

    IEnumerator SpawnMeteors()
    {
        //Countdown bis Beginn der Spawnphase
        yield return new WaitForSeconds(startDelay);

        //Spawnphase
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

            //Power-Up oder Meteor?
            if (Random.Range(1, 101) < powerUpChance) {
                Instantiate(rollForPowerUp(), spawnPosition, spawnRotation);
            } else
            {
                Instantiate(rollForMeteor(), spawnPosition, spawnRotation);
            }

            //Wartezeit zwischen Spawns
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    //gibt einen der drei Meteore zurück
    GameObject rollForMeteor()
    {
        GameObject meteor;

        switch (Random.Range(0, 3))
        {
            case 0:
                meteor = meteorBlue;
                break;
            case 1:
                meteor = meteorRed;
                break;
            case 2:
                meteor = meteorYellow;
                break;
            default:
                meteor = meteorRed;
                break;
        }
        return meteor;
    }

    //gibt eines der hinzugefügten Power Ups zurück
    GameObject rollForPowerUp()
    {
        GameObject powerUp;
        switch(Random.Range(0,2))
        {
            case 0:
                powerUp = powerUp1;
                break;
            case 1:
                powerUp = powerUp2;
                break;
            default:
                powerUp = powerUp1;
                break;
        }
        return powerUp;
    }
}

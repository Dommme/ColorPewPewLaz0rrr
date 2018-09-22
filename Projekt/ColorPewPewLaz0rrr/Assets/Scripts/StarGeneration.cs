using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//füllt den Himmel mit Star-Prefabs
public class StarGeneration : MonoBehaviour {

    public GameObject star;

    public int distance = -500;
    public int height = 10;
    public int width = 10;

	void Start () {

        for (int i = -height; i < height; i++)
        {
            for (int j = -width; j < width; j++)
            {
                Instantiate(star, new Vector3(i * Random.Range(60.0f, 80.0f), j * Random.Range(60.0f, 80.0f), distance), Quaternion.Euler(45, 0, 45), transform);
            }
        }
    }
}

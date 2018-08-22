using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour {

    public GameObject grid;
    public Transform parent;

	// Use this for initialization
	void Start () {
        Instantiate(grid, parent);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider gridCollider)
    {
        Instantiate(grid, parent);
    }
}

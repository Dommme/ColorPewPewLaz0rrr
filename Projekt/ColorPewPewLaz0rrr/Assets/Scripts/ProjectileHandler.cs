using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour {

    public string color;
    public int velocityFactor;
	// Use this for initialization
	void Start () {
        color = "green";
        velocityFactor = 40;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Meteor(Clone)")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log(other.gameObject.name);
        }
    }

}

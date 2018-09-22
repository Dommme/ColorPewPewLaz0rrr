using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterBurnerController : MonoBehaviour {

    public ParticleSystem afterburner;

	void Start () {
        Instantiate(afterburner, transform);
    }

    public void changeColor(string color)
    {
        var main = GameObject.Find("Afterburner(Clone)").GetComponent<ParticleSystem>().main;

        switch (color)
        {
            case "red":
                main.startColor = Color.red;
                break;
            case "blue":
                main.startColor = Color.blue;
                break;
            case "yellow":
                main.startColor = Color.yellow;
                break;
        }
    }
}

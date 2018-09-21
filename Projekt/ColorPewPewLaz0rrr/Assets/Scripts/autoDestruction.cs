using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//zerstört die Partikel Systeme wenn sie durchgelaufen sind

public class autoDestruction : MonoBehaviour {

    private ParticleSystem explosion;

    void Start () {
        explosion = GetComponent<ParticleSystem>();
	}

	void Update () {
		if (explosion)
        {
            if (!explosion.IsAlive())
            {
                Destroy(gameObject);
            }
        }
	}
}

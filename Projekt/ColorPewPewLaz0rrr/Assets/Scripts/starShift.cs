using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starShift : MonoBehaviour {

	// Verschiebt die Sterne um einen zufälligen Wert innerhalb eines festgelegten Intervalls
	void Start () {
        int shift = Random.Range(-20, 20);
        transform.position = new Vector3(transform.localPosition.x + shift, transform.localPosition.y + shift, transform.localPosition.z);
    }
}

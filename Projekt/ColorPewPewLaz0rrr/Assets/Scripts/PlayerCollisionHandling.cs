using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandling : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MeteorController>().istHindernis == true)
        {
            FindObjectOfType<UIscript>().Life(-1);
            //Debug.Log("Hit!");
        }
    }
}

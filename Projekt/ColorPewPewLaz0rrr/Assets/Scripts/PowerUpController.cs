using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {
    
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        //Vorwärtsbewegung
        rb.velocity = new Vector3(0.0f, 0.0f, FindObjectOfType<MeteorSpawner>().meteorSpeed);
    }

    void Update()
    {
        // Power-Ups hinter der Kamera zerstören
        if (transform.position.z > Camera.main.transform.position.z + 1)
        {
            Destroy(this.gameObject);
        }
    }
}

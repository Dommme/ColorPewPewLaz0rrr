using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMover : MonoBehaviour {

    public float speed;

    void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();

        //Vorwärtsbewegung
        rb.velocity = new Vector3(0.0f, 0.0f, speed);
    }

	void Update () {
        // Plane hinter der Kamera zerstören
        if (transform.position.z > Camera.main.transform.position.z + 100)
        {
            Destroy(this.gameObject);
        }
    }
}

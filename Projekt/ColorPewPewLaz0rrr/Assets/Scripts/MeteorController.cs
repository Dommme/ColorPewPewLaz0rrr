using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour {

    public float speed;
    public float tumble;
    public string color;


    void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();

        //Vorwärtsbewegung
        rb.velocity = new Vector3(0.0f, 0.0f, FindObjectOfType<MeteorSpawner>().meteorSpeed);

        //Zufällige Drehung der Meteore
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }

    void Update()
    {
        // Meterore hinter der Kamera zerstören
        if (transform.position.z > Camera.main.transform.position.z + 1)
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {

    public ParticleSystem pickUp;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        //Vorwärtsbewegung
        rb.velocity = new Vector3(0.0f, 0.0f, FindObjectOfType<MeteorSpawner>().meteorSpeed);
    }

    void Update()
    {
        // Power-Ups hinter der Kamera zerstören
        if (transform.position.z > Camera.main.transform.position.z + 100)
        {
            Destroy(this.gameObject);
        }
    }

    //spielt den PowerUp-Sound des Prefabs und zerstört sich danach selbst
    public void playSoundAndDestroy()
    {
        //macht das Objekt unsichtbar
        GetComponent<MeshRenderer>().enabled = false;

        //instantiiert PickUp-PartikelSystem
        Instantiate(pickUp, transform.position, transform.rotation);

        // spielt den Sound ab
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        //zerstört das Objekt nachdem der Sound abgespielt wurde
        Destroy(gameObject, 10f);

    }
}

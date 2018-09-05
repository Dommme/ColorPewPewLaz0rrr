using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {


    public float moveSmoothVar = 3.0f;
    Vector3 playerPos;
    // Use this for initialization

    void Start () {


    }
	
	// Update is called once per frame
	void Update () {

        playerPos = GameObject.Find("Player").GetComponent<PlayerController>().playerPos;
        transform.position = Vector3.Lerp(transform.position, new Vector3( (playerPos[0] / 3.0f), (playerPos[1] / 3.0f), 3.5f), Time.deltaTime * moveSmoothVar);

    }
}

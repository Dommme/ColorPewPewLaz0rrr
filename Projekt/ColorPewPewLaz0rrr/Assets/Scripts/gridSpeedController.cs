using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridSpeedController : MonoBehaviour {

    public float gridSpeed;
    Animator gridAnimator;

    void Start()
    {
        gridAnimator = this.GetComponent<Animator>();
        gridAnimator.speed = gridSpeed;
    }
}

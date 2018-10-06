using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorControl : MonoBehaviour {
    Animator animat;
    public PlayerBehaviour player;
    bool walking;
    bool grounded;
    float idle;
	// Use this for initialization
	void Start () {
        animat = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        walking = player.GetWalking();
        grounded = player.GetGrounded();
        Walking();
        Jumping();
	}
    void IdleController()
    {
        idle = animat.GetFloat("idle");
        if(idle == 0)
        {
            idle = Random.Range(1, 3);
            animat.SetFloat("idle", idle); 
        }
    }
    void Walking()
    {
        animat.SetBool("Walking", (walking && grounded) ? true : false);
    }
    void Jumping()
    {
        animat.SetBool("Jumping", (!grounded) ? true : false);
        animat.SetBool("In Air", (!grounded) ? true : false);
    }
}

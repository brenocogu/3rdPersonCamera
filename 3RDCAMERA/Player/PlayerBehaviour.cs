using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    public float speed; //WalkSpeed for the player container
    public float jumpForce; //JumpForce for the player container
    public GameObject playerEmb; //Player EMB -> this is the tranform point relative to where in the fowards of the player the camera is pointing to. 
    /*
     Q:Why you don't use Camera.x.tranform.foward?
     A:Because it would point to the ground in some moments, getting the player to dig when he had to walk (common issue lol)
     */
    bool grounded; //For the jump
    Rigidbody rbd; //Rigidbody
    bool walking; //For the animator

    void Start()
    {
        grounded = true; 
        Cursor.visible = false; //hide the cursor inside the play area (NOTE: if in fullscreen, this will hide the cursos so if you have any custom options is better to you deactivate this line
        rbd = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        PlayerMove(); //Issue & Tip: get along with FixedUpdate -> when this method is in Update, it causes lag and other perfomance issue. It's in documentation but i'll reafirm here: ALWAYS USE FixedUpdate WHEN RENDER PHYSICS CALCULATION
    }

    void PlayerMove()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime, playerEmb.transform);
        walking = (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) ? true : false;
        if (grounded)
        { 
            if (Input.GetAxisRaw("Jump") > 0)
            {
                rbd.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                grounded = false;
            }
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    public bool GetWalking()
    {
        return walking;
    }

    public bool GetGrounded()
    {
        return grounded;
    }
}
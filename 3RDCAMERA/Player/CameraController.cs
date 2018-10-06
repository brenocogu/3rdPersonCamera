using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    float mouseX, mouseY; //Mouse positioning
    float rotX, rotY; //Rotation from mousePosition * sensibility
    public float sensibility; //YOU CAN'T GUESS WHAT THIS LINE IS

	// Update is called once per frame
	void FixedUpdate () {
        MouseRotation();
	}

    void MouseRotation()
    {
        /////////
        mouseY = Input.GetAxisRaw("MouseHorizontal");
        mouseX = -Input.GetAxisRaw("MouseVertical");
        /////////
        rotX = mouseX * sensibility * Time.deltaTime;
        rotY = mouseY * sensibility * Time.deltaTime;
        /////////
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + rotX, transform.localEulerAngles.y + rotY, 0); //Set the rotation of the CameraHolder
    }
}

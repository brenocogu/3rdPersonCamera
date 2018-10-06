using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorBehaviour : MonoBehaviour {
    public GameObject playerEMB;

	void Update () {
        RotateMovement();
	}
    
    void RotateMovement()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                transform.localEulerAngles = new Vector3(0, playerEMB.transform.localEulerAngles.y, 0);

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    transform.localEulerAngles = new Vector3(0, playerEMB.transform.localEulerAngles.y + 45, 0);
                }

                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    transform.localEulerAngles = new Vector3(0, playerEMB.transform.localEulerAngles.y - 45, 0);
                }
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                transform.localEulerAngles = new Vector3(0, playerEMB.transform.localEulerAngles.y - 180, 0);

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    transform.localEulerAngles = new Vector3(0, playerEMB.transform.localEulerAngles.y + 135, 0);
                }

                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    transform.localEulerAngles = new Vector3(0, playerEMB.transform.localEulerAngles.y - 135, 0);
                }
            }

            if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                transform.localEulerAngles = new Vector3(0, playerEMB.transform.localEulerAngles.y + 90, 0);
            }

            if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                transform.localEulerAngles = new Vector3(0, playerEMB.transform.localEulerAngles.y - 90, 0);
            }
        }
    }
}

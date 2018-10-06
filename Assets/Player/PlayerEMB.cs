using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEMB : MonoBehaviour {
	public GameObject cameraController;
	// Update is called once per frame
	void Update () {
        transform.localEulerAngles = new Vector3(0, cameraController.transform.localEulerAngles.y, 0);
	}
}

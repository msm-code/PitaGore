using UnityEngine;
using System.Collections;

public class GrabsMouse : MonoBehaviour {
	void Update () {
		Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
}

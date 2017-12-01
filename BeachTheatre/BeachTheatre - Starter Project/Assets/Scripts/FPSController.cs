using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour {

	public float speed = 2.0f;
	public float sensitivity = 2.0f;
	public float range = 10.0f;
	private CharacterController player;

	public GameObject eye;

	private float moveForward;
	private float moveRight;

	private float rotX;
	private float rotY;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		player = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {
		
		moveForward = Input.GetAxis ("Vertical") * speed;
		moveRight = Input.GetAxis ("Horizontal") * speed;



		rotX = Input.GetAxis ("Mouse X") * sensitivity;
		rotY -= Input.GetAxis ("Mouse Y") * sensitivity;
		rotY = Mathf.Clamp (rotY, -60f, 60f);

		Vector3 movement = new Vector3 (moveRight, 0, moveForward);
		transform.Rotate (0, rotX, 0);
		eye.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
		movement = transform.rotation * movement;
		player.Move (movement * Time.deltaTime);

		if (Input.GetButtonDown ("Fire1")) {
			Shoot ();
		}
	}

	void Shoot(){
		RaycastHit hit;
		if (Physics.Raycast (eye.transform.position, eye.transform.forward, out hit, range)) {
			Debug.Log (hit.transform.name);
		}
	}
}
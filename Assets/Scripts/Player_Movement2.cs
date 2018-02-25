using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement2 : MonoBehaviour {
	public Joystick joystick;
	private GameObject target;
	private Rigidbody rb;
	public float maxSpeed = 5;
	public float speed = 3;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		target = GameObject.Find ("Target");
	}
	

	void FixedUpdate () {
		Vector3 dir = Vector3.zero;
		dir.x = joystick.Horizontal();
		dir.z = joystick.Vertical();
	

		if (rb.velocity.magnitude > maxSpeed) {
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}
		if (dir != new Vector3 (0, 0, 0)) {
			transform.rotation = Quaternion.LookRotation(dir);
		}
		Debug.Log (Quaternion.LookRotation(dir));
		rb.AddForce (dir.z * target.transform.forward * speed);
		rb.AddForce (dir.x * target.transform.right * speed);
	}
}

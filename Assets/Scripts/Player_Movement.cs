using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
	public Joystick joystick;
	private GameObject target;
	private Rigidbody rb;
	private float maxSpeed = 5;
	private float speed = 4;
	private Vector3 dir2;

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
		if (dir.x != 0) {
			/* dir.x es negativo si esta el joystick a la dereha, y positivo si esta a la izquierda
			 * el problema radica cuando esta al centro, pero tiene movimiento en dir.z (hacia arriba o hacia abajo)
			 * hay que buscar la forma de fusionar dir.x y dir.z
			 */

			//Roto la referencia
			target.transform.rotation = Quaternion.LookRotation (dir);
			//Roto el barco, el valor al ultimo es la velocidad del giro
			transform.rotation = Quaternion.RotateTowards (transform.rotation, target.transform.rotation, Time.deltaTime * 20);
			//Rotacion lateral
			//BUG: Cuando el barco mira hacia nosotros hay qeu invertir la rotacion en z porque se inclina HACIA la curva
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, dir.x * 5);
			//Aplico la fuerza hacia donde mira
			rb.AddForce (transform.forward * speed);
		} else {
			//Reinicia la rotacion lateral
			target.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 0);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, target.transform.rotation, Time.deltaTime * 15);
		}
	}
}

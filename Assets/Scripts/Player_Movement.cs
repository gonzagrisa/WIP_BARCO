using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

	public float speed = 1.0f;
	public float rotationSpeed = 0.5f;
	public float anguloRotacion = 10.0f;
	public float giroSpeed = 1.0f;
	public Transform model;

	void Start() {
		speed /= 10.0f;
	}

	void FixedUpdate() {
		transform.Translate (model.forward * speed);
		if (Input.GetKey(KeyCode.A)) {
			//Movimiento Jugador
			transform.Translate (-model.right * speed);

			//Rotacion player
			Quaternion rotPlayer = Quaternion.Euler (transform.rotation.x, transform.rotation.y - giroSpeed, transform.rotation.z);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, rotPlayer, rotationSpeed);

			//Rotacion modelo
			Quaternion rotModelo = Quaternion.Euler (0.0f, 0.0f, anguloRotacion);
			model.localRotation = Quaternion.RotateTowards (model.rotation, rotModelo, rotationSpeed);
		}
		else if (Input.GetKey(KeyCode.D)) {
			//Movimiento Jugador
			transform.Translate (model.right * speed);

			//Rotacion player
			Quaternion rotPlayer = Quaternion.Euler (transform.rotation.x, transform.rotation.y + giroSpeed, transform.rotation.z);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, rotPlayer, rotationSpeed);

			//Rotacion modelo
			Quaternion rotModelo = Quaternion.Euler (0.0f, 0.0f, -anguloRotacion);
			model.localRotation = Quaternion.RotateTowards (model.rotation, rotModelo, rotationSpeed);
		}
		else {
			//Resetear rotacion modelo
			model.localRotation = Quaternion.RotateTowards (model.rotation, Quaternion.identity, rotationSpeed);
		}

	}

}

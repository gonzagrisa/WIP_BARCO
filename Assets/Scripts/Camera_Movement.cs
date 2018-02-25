using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour {

	public Transform target;

	private Vector3 offset;

	void Start() {
		offset = transform.position;
	}

	void Update() {
		transform.position = target.position + offset;
	}

}

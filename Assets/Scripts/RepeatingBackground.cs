using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {
	BoxCollider2D boxCollider;
	float length;

	// Start is called before the first frame update
	void Start() {
		boxCollider = GetComponent<BoxCollider2D>();
		length = boxCollider.size.x;
	}

	// Update is called once per frame
	void Update() {
        if (transform.position.x < -length) {
            repositionBackground();
        }
	}

	void repositionBackground() {
		var offset = length * 3;
		transform.position = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public bool IsDead { get; private set; }
	Rigidbody2D rb;
	Animator anim;

	[SerializeField]
	float upForce;

	// Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update() {
		// Do not allow input when the player is dead
		if (IsDead)
			return;

		// If the player has pressed the mouse button, flap
		if (Input.GetMouseButtonDown(0)) {
			rb.velocity = Vector2.zero; // Shortcut for new Vector2(0, 0);
			rb.AddForce(new Vector2(0, upForce));
			anim.SetTrigger("Flap");
		}
	}

	// Unity's built-in method for detecting collisions
	void OnCollisionEnter2D() {
		// Set the player to dead if it hits another collider (ground or icicle!)
		IsDead = true;
	}
}

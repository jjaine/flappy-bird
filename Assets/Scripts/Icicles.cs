using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Icicles : MonoBehaviour {
    Action scoreCallback;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Bird>() != null) {
            scoreCallback();
        }
    }

    public void SetScoreCallback(Action scoreCallback) {
        this.scoreCallback = scoreCallback;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {
    Rigidbody2D rb;
    [SerializeField]
    float scrollSpeed;
    Bird bird;

	// Start is called before the first frame update
	void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(scrollSpeed, 0);

        bird = GameObject.Find("Bird").GetComponent<Bird>();
	}

	// Update is called once per frame
	void Update() {
        if (bird.IsDead) {
            stopScrolling();
        }
	}

    void stopScrolling() {
        rb.velocity = Vector2.zero;
    }
}

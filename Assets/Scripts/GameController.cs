using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour {
	[SerializeField]
	GameObject gameOverText;
    [SerializeField]
    TMP_Text scoreText;
	[SerializeField]
	Bird bird;
    IciclePool iciclePool;
    int score = 0;

	// Start is called before the first frame update
	void Start() {
        iciclePool = GetComponent<IciclePool>();
        iciclePool.SetScoreCallback(birdScored);
	}

	// Update is called once per frame
	void Update() {
		if (bird.IsDead) {
			birdDied();
		}

        if (bird.IsDead && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    void birdScored() {
        if (bird.IsDead) {
            return;
        }

        score++;
        scoreText.text = $"Score: {score}";
    }

	void birdDied() {
		if (!gameOverText.activeSelf) {
			gameOverText.SetActive(true);
            iciclePool.Active = false;
		}
	}
}

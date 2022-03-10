using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IciclePool : MonoBehaviour {
	[SerializeField]
	GameObject iciclesPrefab;
	[SerializeField]
	int poolSize;

	GameObject[] icicles;
    Vector2 poolPosition = new Vector2(-100, -100);

    float spawnRate = 5;
    float timeSinceLastSpawned = 0;
    public bool Active = true;

    int icicleIdx = 0;
    float spawnPositionX = 40;

    Action scoreCallback;

	// Start is called before the first frame update
	void Start() {
		icicles = new GameObject[poolSize];
		for (int i = 0; i < poolSize; i++) {
			icicles[i] = Instantiate(iciclesPrefab, poolPosition, Quaternion.identity);
            icicles[i].GetComponent<Icicles>().SetScoreCallback(scoreCallback);
		}
	}

    public void SetScoreCallback(Action scoreCallback) {
        this.scoreCallback = scoreCallback;
    }

	// Update is called once per frame
	void Update() {
        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned > spawnRate) {
            timeSinceLastSpawned = 0;
            var spawnPositionY = UnityEngine.Random.Range(-2f, 2f);
            icicles[icicleIdx].transform.position = new Vector2(spawnPositionX, spawnPositionY);
            icicleIdx++;

            if (icicleIdx >= poolSize) {
                icicleIdx = 0;
            }
        }
	}
}

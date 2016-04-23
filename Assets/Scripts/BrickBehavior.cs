using UnityEngine;
using System.Collections;

public class BrickBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col) {
        // Destroy the whole Block
        Destroy(gameObject);
    }
}

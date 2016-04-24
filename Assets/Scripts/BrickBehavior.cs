using UnityEngine;
using System.Collections;

public class BrickBehavior : MonoBehaviour {
    public ParticleSystem brickDestroyEffect;

    private ScreenShake camEffect;

    // Use this for initialization
    void Start () {
        camEffect = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col) {
        Instantiate(brickDestroyEffect, transform.position, Quaternion.identity);
        camEffect.enabled = true;

        GameObject.FindGameObjectWithTag("mainAudio").GetComponent<AudioSource>().Play();

        // Destroy the brick
        Destroy(gameObject);
    }
}

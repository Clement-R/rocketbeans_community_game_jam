using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
    public float speed = 100.0f;
    private float baseSpeed;
    private GameObject ps;
    private ScreenShake camEffect;
    
    void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        ps = GameObject.FindGameObjectWithTag("touchEffectPS");
        baseSpeed = speed;
    }

    void Update() {
        // Gogo rotation !
        transform.Rotate(new Vector3(0, 0, 10));
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "paddle") {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Play touch effect
            Vector3 newPos = transform.position;
            newPos.y = newPos.y - 5;
            ps.transform.position = newPos;
            ps.GetComponentInChildren<ParticleSystem>().Play();

            // Play paddle touch sound
            GameObject.FindGameObjectWithTag("paddle").GetComponent<AudioSource>().Play();

            // Set Velocity with dir * speed
            if (speed < baseSpeed + 50) {
                speed += 2;
            }
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        } else {
            // Play ball touch sound
            GetComponent<AudioSource>().Play();
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth) {
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    void OnBecameInvisible() {
        StartCoroutine(Revive(0.5f));
    }

    IEnumerator Revive(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        transform.position = new Vector3(0, -100, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        StartCoroutine(Launch(1.0f));
    }

    IEnumerator Launch(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
}

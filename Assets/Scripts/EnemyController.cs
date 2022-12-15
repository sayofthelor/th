using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Transform playerTransform;
    private Rigidbody2D rb;

    void Start() {
        playerTransform = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float distance = DistanceAsFloat(playerTransform.position, transform.position);
        if (distance <= 5) {
            rb.AddForce((playerTransform.position - transform.position).normalized, ForceMode2D.Impulse);
        }
    }

    float DistanceAsFloat(Vector2 a, Vector2 b) {
        return Mathf.Sqrt(Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.y - b.y, 2));
    }
}

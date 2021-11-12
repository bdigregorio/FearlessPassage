using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {
    void Start() {
        Debug.Log($"{gameObject.name} is monitoring for collisions");
    }

    void OnCollisionEnter(Collision other) {
        Debug.Log($"{gameObject.name} has collided with {other.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log($"{gameObject.name} has been triggered by {other.gameObject.name}");
    }
}

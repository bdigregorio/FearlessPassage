using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {
    void Start() {
        Debug.Log($"{this.name} is monitoring for collisions");
    }

    void OnCollisionEnter(Collision other) {
        Debug.Log($"{this.name} has collided with {other.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log($"{this.name} has been triggered by {other.gameObject.name}");
    }
}

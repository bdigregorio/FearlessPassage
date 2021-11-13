using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    void OnParticleCollision(GameObject other) {
        Debug.Log($"{this.name} has been triggered by {other.gameObject.name}");
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
    [SerializeField] float sceneTransitionDelay = 1f;

    void OnTriggerEnter(Collider other) {
        StartCrashSequence();
    }

    void StartCrashSequence() {
        var playerController = GetComponent<PlayerController>();
        if (playerController is null) return;
        playerController.enabled = false;
        Invoke(nameof(RestartScene), sceneTransitionDelay);
    }

    void RestartScene() {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}

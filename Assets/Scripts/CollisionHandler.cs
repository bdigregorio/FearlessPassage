using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
    [SerializeField] float sceneTransitionDelay = 1f;
    [SerializeField] ParticleSystem explosionFx;

    void OnTriggerEnter(Collider other) {
        StartCrashSequence();
    }

    void StartCrashSequence() {
        DisableControls();
        PlayExplosionFx();
        Invoke(nameof(RestartScene), sceneTransitionDelay);
    }

    void DisableControls() {
        var playerController = GetComponent<PlayerController>();
        if (playerController is null) return;
        playerController.enabled = false;
    }

    void PlayExplosionFx() {
        explosionFx.Play();
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }

    void RestartScene() {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}

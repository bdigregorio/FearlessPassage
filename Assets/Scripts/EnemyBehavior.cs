using System.Collections;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    [SerializeField] ParticleSystem explosionFx;
    [SerializeField] ParticleSystem damageFx;
    [SerializeField] int pointValue = 5;
    [SerializeField] private int remainingHealth = 1;
    
    Scoreboard scoreBoard;
    GameObject enemyVfxContainer;

    void Start() {
        BuildCache();
        AddRigidbody();
    }
    
    void OnParticleCollision(GameObject other) {
        ProcessDamage();
    }

    void OnTriggerEnter(Collider other) {
        DestroySequence();
    }

    void AddRigidbody() {
        var rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void BuildCache() {
        scoreBoard = FindObjectOfType<Scoreboard>();
        enemyVfxContainer = GameObject.FindWithTag("EnemyVFXContainer");
    }

    void ProcessDamage() {
        scoreBoard.IncreaseScore(pointValue);
        if (--remainingHealth < 1) {
            DestroySequence();
        }
        else {
            PlayVfx(damageFx);
        }
    }

    void PlayVfx(ParticleSystem particleClass) {
        var fx = Instantiate(particleClass, transform.position, Quaternion.identity);
        fx.transform.parent = enemyVfxContainer.transform;
        fx.Play();
    }

    void DestroySequence() {
            PlayVfx(explosionFx);
            Destroy(this.gameObject);
    }
}

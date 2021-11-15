using System.Collections;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    [SerializeField] ParticleSystem explosionFx;
    [SerializeField] ParticleSystem damageFx;
    [SerializeField] Transform enemyVfxParent;
    [SerializeField] int pointValue = 5;
    [SerializeField] private int remainingHealth = 1;
    
    Scoreboard scoreBoard;

    void Start() {
        CacheScoreboard();
        AddRigidbody();
    }
    
    void OnParticleCollision(GameObject other) {
        ProcessDamage();
    }

    void OnTriggerEnter(Collider other) {
        PlayVfx(explosionFx);
    }

    void AddRigidbody() {
        var rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void CacheScoreboard() {
        scoreBoard = FindObjectOfType<Scoreboard>();
    }

    void ProcessDamage() {
        scoreBoard.IncreaseScore(pointValue);
        if (--remainingHealth < 1) {
            PlayVfx(explosionFx);
            Destroy(this.gameObject);
        }
        else {
            PlayVfx(damageFx);
        }
    }

    void PlayVfx(ParticleSystem particleClass) {
        var fx = Instantiate(particleClass, transform.position, Quaternion.identity);
        fx.transform.parent = enemyVfxParent;
        fx.Play();
    }
}

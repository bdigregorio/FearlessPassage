using System.Collections;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    [SerializeField] ParticleSystem explosionFx;
    [SerializeField] Transform enemyVfxParent;
    [SerializeField] int pointValue = 5;
    [SerializeField] private int remainingHealth = 1;
    
    Scoreboard scoreBoard;
    

    void Start() {
        scoreBoard = FindObjectOfType<Scoreboard>();
    }
    
    void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    void OnTriggerEnter(Collider other) {
        HandleExplosion();
    }

    void ProcessHit() {
        if (--remainingHealth < 1) {
            HandleExplosion();
        }
        else {
            HandleDamage();
        }
    }

    void HandleDamage() {
        scoreBoard.IncreaseScore(pointValue);
        StartCoroutine(nameof(FlashDamage));
    }

    void HandleExplosion() {
        scoreBoard.IncreaseScore(pointValue);
        var fx = Instantiate(explosionFx, transform.position, Quaternion.identity);
        fx.transform.parent = enemyVfxParent;
        fx.Play();
        Destroy(this.gameObject);
    }

    IEnumerator FlashDamage() {
        var material = GetComponent<MeshRenderer>().material;
        material.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        material.color = Color.white;
    }
}

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
        Debug.Log($"{this.name} has taken 1 damage");
    }

    void HandleExplosion() {
        scoreBoard.IncreaseScore(pointValue);
        var fx = Instantiate(explosionFx, transform.position, Quaternion.identity);
        fx.transform.parent = enemyVfxParent;
        fx.Play();
        Destroy(this.gameObject);
    }
}

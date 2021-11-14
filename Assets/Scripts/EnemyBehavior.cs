using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    [SerializeField] ParticleSystem explosionFx;
    [SerializeField] Transform enemyVfxParent;
    [SerializeField] int pointValue = 5;
    
    Scoreboard scoreBoard;

    void Start() {
        scoreBoard = FindObjectOfType<Scoreboard>();
    }
    
    void OnParticleCollision(GameObject other) {
        HandleExplosion();
    }

    void OnTriggerEnter(Collider other) {
        HandleExplosion();
    }

    void HandleExplosion() {
        scoreBoard.IncreaseScore(pointValue);
        var fx = Instantiate(explosionFx, transform.position, Quaternion.identity);
        fx.transform.parent = enemyVfxParent;
        fx.Play();
        Destroy(this.gameObject);
    }
}

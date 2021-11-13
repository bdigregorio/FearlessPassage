using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    [SerializeField] ParticleSystem explosionFx;
    [SerializeField] Transform enemyVfxParent;
    
    void OnParticleCollision(GameObject other) {
        HandleExplosion();
    }

    void OnTriggerEnter(Collider other) {
        HandleExplosion();
    }

    void HandleExplosion() {
        var fx = Instantiate(explosionFx, transform.position, Quaternion.identity);
        fx.transform.parent = enemyVfxParent;
        fx.Play();
        Destroy(this.gameObject);
    }
}

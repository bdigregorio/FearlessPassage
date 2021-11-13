using UnityEngine;

public class SelfDestruct : MonoBehaviour {
    [SerializeField] private float selfDestructTime = 1.5f;
    
    void Start() {
        Destroy(this.gameObject, selfDestructTime);   
    }
}

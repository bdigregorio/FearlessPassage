using UnityEngine;

public class PlayerController : MonoBehaviour {

    void Update() {
        HandleInput();
    }

    void HandleInput() {
        var xInputValue = Input.GetAxis("Horizontal");
        var yInputValue = Input.GetAxis("Vertical");
        var localPosition = transform.localPosition;
        var xPositionTarget = localPosition.x + 0.1f;
        var yPositionTarget = localPosition.y + 0.1f;

        transform.localPosition = new Vector3(
            xPositionTarget,
            yPositionTarget,
            localPosition.z
        );
    }
}
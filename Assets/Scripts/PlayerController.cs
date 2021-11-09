using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float movementFactor = 10f;

    void Update() {
        HandleInput();
    }

    void HandleInput() {
        var localPosition = transform.localPosition;
        
        var xInputValue = Input.GetAxis("Horizontal");
        var xOffset = xInputValue * Time.deltaTime * movementFactor;
        var xTargetPosition = localPosition.x + xOffset;

        var yInputValue = Input.GetAxis("Vertical");
        var yOffset = yInputValue * Time.deltaTime * movementFactor;
        var yTargetPosition = localPosition.y + yOffset;
        
        transform.localPosition = new Vector3(
            xTargetPosition,
            yTargetPosition,
            localPosition.z
        );
    }
}
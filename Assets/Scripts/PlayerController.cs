using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float movementFactor = 30f;
    [SerializeField] float xRange = 15f;
    [SerializeField] float yMin = -5f;
    [SerializeField] private float yMax = 15f;

    void Update() {
        HandleInput();
    }

    void HandleInput() {
        var localPosition = transform.localPosition;
        
        var xInputValue = Input.GetAxis("Horizontal");
        var xOffset = xInputValue * Time.deltaTime * movementFactor;
        var xPosRaw = localPosition.x + xOffset;
        var xClamped = Mathf.Clamp(xPosRaw, -xRange, xRange);

        var yInputValue = Input.GetAxis("Vertical");
        var yOffset = yInputValue * Time.deltaTime * movementFactor;
        var yPosRaw = localPosition.y + yOffset;
        var yClamped = Mathf.Clamp(yPosRaw, yMin, yMax);
        
        transform.localPosition = new Vector3(
            xClamped,
            yClamped,
            localPosition.z
        );
    }
}
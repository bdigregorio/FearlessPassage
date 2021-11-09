using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float movementFactor = 30f;
    [SerializeField] float xRange = 15f;
    [SerializeField] float yRange = 15;
    [SerializeField] float pitchPositionFactor = -1.35f;
    [SerializeField] private float pitchInputFactor = -25f;

    float xInputValue, yInputValue;

    void Update() {
        ReadInputValues();
        HandleTranslation();
        HandleRotation();
    }

    void ReadInputValues() {
        xInputValue = Input.GetAxis("Horizontal");
        yInputValue = Input.GetAxis("Vertical");
    }

    void HandleTranslation() {
        var localPosition = transform.localPosition;
        
        var xOffset = xInputValue * Time.deltaTime * movementFactor;
        var xPosRaw = localPosition.x + xOffset;
        var xClamped = Mathf.Clamp(xPosRaw, -xRange, xRange);

        var yOffset = yInputValue * Time.deltaTime * movementFactor;
        var yPosRaw = localPosition.y + yOffset;
        var yClamped = Mathf.Clamp(yPosRaw, -yRange, yRange);
        
        transform.localPosition = new Vector3(
            xClamped,
            yClamped,
            localPosition.z
        );
    }

    void HandleRotation() {
        var localPosition = transform.localPosition;
        
        var pitchFromRelativeYPosition = localPosition.y * pitchPositionFactor;
        var pitchFromYInput = yInputValue * pitchInputFactor;
        var computedPitch = pitchFromRelativeYPosition + pitchFromYInput;
        
        var computedYaw = localPosition.x * -pitchPositionFactor;
        var computedRoll = xInputValue * pitchInputFactor;
        
        transform.localRotation = Quaternion.Euler(computedPitch, computedYaw, computedRoll);
    }
}
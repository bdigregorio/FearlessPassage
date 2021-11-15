using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("Translation Params")]
    [Tooltip("The relative horizontal range the player is allowed to move between")]
    [SerializeField] float xRange = 15f;
    [Tooltip("The relative vertical range the player is allowed to move between")]
    [SerializeField] float yRange = 15;
    [Tooltip("The speed of horizontal and vertical translation")]
    [SerializeField] float movementFactor = 30f;
    
    [Header("Rotation Params")]
    [Tooltip("Tunes how much pitch is affected by vertical position")]
    [SerializeField] float pitchPositionFactor = -1.35f;
    [Tooltip("Tunes how much pitch is affected by vertical input")]
    [SerializeField] float pitchInputFactor = -25f;
    [Tooltip("Tunes how much yaw is affected by horizontal position")]
    [SerializeField] float yawPositionFactor = 2f;
    [Tooltip("Tunes how much roll is affected by horizontal input")]
    [SerializeField] float rollInputFactor = -35f;

    [Header("Game Object References")]
    [Tooltip("References to any lasers the player owns")]
    [SerializeField] GameObject[] laserObjects;
    
    float xInputValue, yInputValue;

    void Update() {
        ReadInputValues();
        HandleTranslation();
        HandleRotation();
        HandleWeapons();
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
        var computedYaw = localPosition.x * yawPositionFactor;
        var computedRoll = xInputValue * rollInputFactor;
        
        transform.localRotation = Quaternion.Euler(computedPitch, computedYaw, computedRoll);
    }

    void HandleWeapons() { 
        if (Input.GetButton("Fire1")) {
            ToggleLasers(enabledState: true);
        } else {
            ToggleLasers(enabledState: false);
        }
    }

    void ToggleLasers(bool enabledState) {
        if (laserObjects is null || laserObjects.Length == 0) return;
        
        foreach (var laser in laserObjects) {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = enabledState;
        }
    }
}
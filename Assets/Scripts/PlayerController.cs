using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float movementFactor = 30f;
    [SerializeField] float xRange = 15f;
    [SerializeField] float yRange = 15;
    [SerializeField] GameObject[] laserObjects;
    
    [SerializeField] float pitchPositionFactor = -1.35f;
    [SerializeField] float pitchInputFactor = -25f;
    [SerializeField] float yawPositionFactor = 2f;
    [SerializeField] float rollInputFactor = -35f;

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
        foreach (var laser in laserObjects) {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = enabledState;
        }
    }
}